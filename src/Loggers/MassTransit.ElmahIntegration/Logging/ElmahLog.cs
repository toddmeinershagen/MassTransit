namespace MassTransit.ElmahIntegration.Logging
{
    using System;
    using System.Globalization;
    using Elmah;
    using MassTransit.Logging;

    public class ElmahLog : 
        ILog
    {
        readonly ErrorLog _errorLog;
        public static readonly IFormatProvider DefaultFormatProvider = CultureInfo.InvariantCulture;

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
            Log(level, obj, null);
        }

        public void Log(LogLevel level, object message, Exception exception)
        {
            var error = exception == null ? new Error() : new Error(exception);
            error.Message = message == null ? null : message.ToString();
            error.Type = level.ToString();
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

        public void Log(LogLevel level, LogOutputProvider messageProvider)
        {
            Log(level, messageProvider(), null);
        }

        public void LogFormat(LogLevel level, IFormatProvider formatProvider, string format, params object[] args)
        {
            var message = string.Format(formatProvider, format, args);
            Log(level, message);
        }

        public void LogFormat(LogLevel level, string format, params object[] args)
        {
            LogFormat(level, DefaultFormatProvider, format, args);
        }

        public void Debug(object obj)
        {
            Debug(obj, null);
        }

        public void Debug(object obj, Exception exception)
        {
            Log(LogLevel.Debug, obj, exception);
        }

        public void Debug(LogOutputProvider messageProvider)
        {
            Debug(messageProvider());
        }

        public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            var message = string.Format(formatProvider, format, args);
            Debug(message);
        }

        public void DebugFormat(string format, params object[] args)
        {
            DebugFormat(DefaultFormatProvider, format, args);
        }

        public void Info(object obj)
        {
            Info(obj, null);
        }

        public void Info(object obj, Exception exception)
        {
            Log(LogLevel.Info, obj, exception);
        }

        public void Info(LogOutputProvider messageProvider)
        {
            Info(messageProvider());
        }

        public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            var message = string.Format(formatProvider, format, args);
            Info(message);
        }

        public void InfoFormat(string format, params object[] args)
        {
            InfoFormat(DefaultFormatProvider, format, args);
        }

        public void Warn(object obj)
        {
            Warn(obj, null);
        }

        public void Warn(object obj, Exception exception)
        {
            Log(LogLevel.Warn, obj, exception);
        }

        public void Warn(LogOutputProvider messageProvider)
        {
            Warn(messageProvider());
        }

        public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            var message = string.Format(formatProvider, format, args);
            Warn(message);
        }

        public void WarnFormat(string format, params object[] args)
        {
            WarnFormat(DefaultFormatProvider, format, args);
        }

        public void Error(object obj)
        {
            Error(obj, null);
        }

        public void Error(object obj, Exception exception)
        {
            Log(LogLevel.Error, obj, exception);
        }

        public void Error(LogOutputProvider messageProvider)
        {
            Error(messageProvider());
        }

        public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            var message = string.Format(formatProvider, format, args);
            Error(message);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            ErrorFormat(DefaultFormatProvider, format, args);
        }

        public void Fatal(object obj)
        {
            Fatal(obj, null);
        }

        public void Fatal(object obj, Exception exception)
        {
            Log(LogLevel.Fatal, obj, exception);
        }

        public void Fatal(LogOutputProvider messageProvider)
        {
            Fatal(messageProvider());
        }

        public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            var message = string.Format(formatProvider, format, args);
            Fatal(message);
        }

        public void FatalFormat(string format, params object[] args)
        {
            FatalFormat(DefaultFormatProvider, format, args);
        }
    }
}
