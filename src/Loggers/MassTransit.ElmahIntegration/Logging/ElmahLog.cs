﻿// Copyright 2007-2011 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
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
        readonly LogLevel _level;
        public static readonly IFormatProvider DefaultFormatProvider = CultureInfo.InvariantCulture;

        public ElmahLog(ErrorLog errorLog, LogLevel level)
        {
            _errorLog = errorLog;
            _level = level;

            IsDebugEnabled = IsEnabled(LogLevel.Debug);
            IsInfoEnabled = IsEnabled(LogLevel.Info);
            IsWarnEnabled = IsEnabled(LogLevel.Warn);
            IsErrorEnabled = IsEnabled(LogLevel.Error);
            IsFatalEnabled = IsEnabled(LogLevel.Fatal);
        }

        private bool IsEnabled(LogLevel level)
        {
            return level <= _level;
        }

        public bool IsDebugEnabled { get; private set; }
        public bool IsInfoEnabled { get; private set; }
        public bool IsWarnEnabled { get; private set; }
        public bool IsErrorEnabled { get; private set; }
        public bool IsFatalEnabled { get; private set; }
        
        public void Log(LogLevel minimumLevel, object obj)
        {
            Log(minimumLevel, obj, null);
        }

        public void Log(LogLevel minimumLevel, object message, Exception exception)
        {
            if (IsEnabled(minimumLevel))
            {
                var error = exception == null ? new Error() : new Error(exception);
                error.Message = message == null ? null : message.ToString();
                error.Type = minimumLevel.ToString();
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

        public void Log(LogLevel minimumLevel, LogOutputProvider messageProvider)
        {
            Log(minimumLevel, messageProvider(), null);
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
