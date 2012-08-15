namespace MassTransit.Transports.RabbitMq
{
    using System;
    using Magnum.Extensions;
    using RabbitMQ.Client;
    using log4net;

    public class RabbitMqConnection :
        Connection
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(RabbitMqConnection));
        readonly ConnectionFactory _connectionFactory;
        IConnection _connection;
        bool _disposed;

        public RabbitMqConnection(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IConnection Connection
        {
            get { return _connection; }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Connect()
        {
            Disconnect();

            _connection = _connectionFactory.CreateConnection();
        }

        public void Disconnect()
        {
            try
            {
                if (_connection != null)
                {
                    try
                    {
                        if (_connection.IsOpen)
                            _connection.Close(200, "disconnected");
                    }
                    catch (Exception ex)
                    {
                        _log.Warn("Exception while closing RabbitMQ connection", ex);
                    }

                    _connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                _log.Warn("Exception disposing of RabbitMQ connection", ex);
            }
            finally
            {
                _connection = null;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            if (_disposed)
                throw new ObjectDisposedException("RabbitMqConnection for {0}:{1}/{2}"
                    .FormatWith(_connectionFactory.HostName, _connectionFactory.Port, _connectionFactory.VirtualHost),
                    "Cannot dispose a connection twice");

            try
            {
                Disconnect();
            }
            finally
            {
                _disposed = true;
            }
        }
    }
}