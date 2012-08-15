namespace MassTransit.Transports
{
    using System;
    using System.Threading;
    using Magnum.Extensions;
    using log4net;

    public class DefaultConnectionPolicy :
        ConnectionPolicy
    {
        readonly ConnectionHandler _connectionHandler;
        readonly ReaderWriterLockSlim _connectionlLock = new ReaderWriterLockSlim();
        readonly ILog _log = LogManager.GetLogger(typeof(DefaultConnectionPolicy));
        readonly TimeSpan _reconnectDelay;

        public DefaultConnectionPolicy(ConnectionHandler connectionHandler)
        {
            _connectionHandler = connectionHandler;
            _reconnectDelay = 1.Seconds();
        }

        public void Execute(Action callback)
        {
            try
            {
                try
                {
                    // wait here so we can be sure that there is not a reconnect in progress
                    _connectionlLock.EnterReadLock();
                    callback();
                }
                finally
                {
                    _connectionlLock.ExitReadLock();
                }
            }
            catch (InvalidConnectionException ex)
            {
                _log.Warn("Invalid Connection when executing callback", ex.InnerException);

                Reconnect();

                if (_log.IsDebugEnabled)
                {
                    _log.Debug("Retrying callback after reconnect.");
                }

                callback();
            }
        }

        void Reconnect()
        {
            if (_connectionlLock.TryEnterWriteLock((int)_reconnectDelay.TotalMilliseconds/2))
            {
                try
                {
                    if (_log.IsDebugEnabled)
                    {
                        _log.Debug("Disconnecting connection handler.");
                    }
                    _connectionHandler.Disconnect();

                    if (_reconnectDelay > TimeSpan.Zero)
                        Thread.Sleep(_reconnectDelay);

                    if (_log.IsDebugEnabled)
                    {
                        _log.Debug("Re-connecting connection handler...");
                    }
                    _connectionHandler.Connect();
                }
                catch (Exception ex)
                {
                    _log.Warn("Failed to reconnect, deferring to connection policy for reconnection");
                    _connectionHandler.ForceReconnect(_reconnectDelay);
                }
                finally
                {
                    _connectionlLock.ExitWriteLock();
                }
            }
            else
            {
                try
                {
                    _connectionlLock.EnterReadLock();
                    if (_log.IsDebugEnabled)
                    {
                        _log.Debug("Waiting for reconnect in another thread.");
                    }
                }
                finally
                {
                    _connectionlLock.ExitReadLock();
                }
            }
        }
    }
}