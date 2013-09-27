namespace MassTransit.ElmahIntegration.Logging
{
    using System;
    using Elmah;
    using MassTransit.Logging;

    public class ElmahLog : 
        ILog
    {
        readonly ErrorLog _errorLog;

        public ElmahLog(ErrorLog errorLog)
        {
            _errorLog = errorLog;

            IsDebugEnabled = true;
            IsInfoEnabled = true;
            IsWarnEnabled = true;
            IsErrorEnabled = true;
            IsFatalEnabled = true;
        }

        public bool IsDebugEnabled { get; private set; }
        public bool IsInfoEnabled { get; private set; }
        public bool IsWarnEnabled { get; private set; }
        public bool IsErrorEnabled { get; private set; }
        public bool IsFatalEnabled { get; private set; }
        
        public void Log(LogLevel level, object obj)
        {
            throw new NotImplementedException();
        }

        public void Log(LogLevel level, object obj, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void Log(LogLevel level, LogOutputProvider messageProvider)
        {
            throw new NotImplementedException();
        }

        public void LogFormat(LogLevel level, IFormatProvider formatProvider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void LogFormat(LogLevel level, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Debug(object obj)
        {
            throw new NotImplementedException();
        }

        public void Debug(object obj, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void Debug(LogOutputProvider messageProvider)
        {
            WriteInternal(LogLevel.Debug, messageProvider());
        }

        public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void DebugFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Info(object obj)
        {
            throw new NotImplementedException();
        }

        public void Info(object obj, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void Info(LogOutputProvider messageProvider)
        {
            throw new NotImplementedException();
        }

        public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void InfoFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Warn(object obj)
        {
            throw new NotImplementedException();
        }

        public void Warn(object obj, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void Warn(LogOutputProvider messageProvider)
        {
            throw new NotImplementedException();
        }

        public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void WarnFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Error(object obj)
        {
            throw new NotImplementedException();
        }

        public void Error(object obj, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void Error(LogOutputProvider messageProvider)
        {
            throw new NotImplementedException();
        }

        public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void ErrorFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Fatal(object obj)
        {
            throw new NotImplementedException();
        }

        public void Fatal(object obj, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void Fatal(LogOutputProvider messageProvider)
        {
            WriteInternal(LogLevel.Fatal, messageProvider());
        }

        public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void FatalFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        private void WriteInternal(LogLevel logLevel, object message, Exception exception = null)
        {
            var error = exception == null ? new Error() : new Error(exception);
            error.Message = message == null ? null : message.ToString();
            error.Type = logLevel.ToString();
            error.Time = DateTime.Now;

            try
            {
                _errorLog.Log(error);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Error: {0}\n{1}", ex.Message, ex.StackTrace);
            }
        }
    }
}
