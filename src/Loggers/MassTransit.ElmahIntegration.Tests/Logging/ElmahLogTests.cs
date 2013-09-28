// Copyright 2007-2011 Chris Patterson, Dru Sellers, Travis Smith, et. al.
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
namespace MassTransit.ElmahIntegration.Tests.Logging
{
    using System;
    using Elmah;
    using ElmahIntegration.Logging;
    using MassTransit.Logging;
    using NUnit.Framework;

    [TestFixture]
    public class ElmahLogTests
    {
        Action<ElmahLog, LogOutputProvider, string, Exception> _action;
        Action<Error, string, Exception> _assertion;
        const string Format = "You are number {0}, {1}.";
        const string FormattedMessage = "You are number 1, Tammy.";
        readonly object[] _args = { 1, "Tammy" };

        [TearDown]
        public void TearDown()
        {
            _action = null;
            _assertion = null;
        }

        [Test]
        public void given_message_provider_when_logging_debug_should_log_message_as_debug()
        {
            _action = (log, provider, message, exception) => log.Debug(provider);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Debug);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_object_when_logging_debug_should_log_message_as_debug()
        {
            _action = (log, provider, message, exception) => log.Debug(message);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Debug);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_object_and_exception_when_logging_debug_should_log_message_and_exception_as_debug()
        {
            _action = (log, provider, message, exception) => log.Debug(message, exception);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Debug, exception);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_format_provider_and_format_when_logging_debug_should_log_message_as_debug()
        {
            Action<ElmahLog> action = (log) => log.DebugFormat(ElmahLog.DefaultFormatProvider, Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Debug);

            Assert(action, assertion);
        }

        [Test]
        public void given_format_when_logging_debug_should_log_message_as_debug()
        {
            Action<ElmahLog> action = (log) => log.DebugFormat(Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Debug);

            Assert(action, assertion);
        }

        [Test]
        public void given_message_provider_when_logging_info_should_log_message_as_info()
        {
            _action = (log, provider, message, exception) => log.Info(provider);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Info);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_object_when_logging_info_should_log_message_as_info()
        {
            _action = (log, provider, message, exception) => log.Info(message);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Info);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_object_and_exception_when_logging_info_should_log_message_and_exception_as_info()
        {
            _action = (log, provider, message, exception) => log.Info(message, exception);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Info, exception);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_format_provider_and_format_when_logging_info_should_log_message_as_info()
        {
            Action<ElmahLog> action = (log) => log.InfoFormat(ElmahLog.DefaultFormatProvider, Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Info);

            Assert(action, assertion);
        }

        [Test]
        public void given_format_when_logging_info_should_log_message_as_info()
        {
            Action<ElmahLog> action = (log) => log.InfoFormat(Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Info);

            Assert(action, assertion);
        }

        [Test]
        public void given_message_provider_when_logging_warning_should_log_message_as_warning()
        {
            _action = (log, provider, message, exception) => log.Warn(provider);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Warn);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_object_when_logging_warning_should_log_message_as_warning()
        {
            _action = (log, provider, message, exception) => log.Warn(message);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Warn);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_object_and_exception_when_logging_debug_should_warning_message_and_exception_as_warning()
        {
            _action = (log, provider, message, exception) => log.Warn(message, exception);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Warn, exception);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_format_provider_and_format_when_logging_warning_should_log_message_as_warning()
        {
            Action<ElmahLog> action = (log) => log.WarnFormat(ElmahLog.DefaultFormatProvider, Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Warn);

            Assert(action, assertion);
        }

        [Test]
        public void given_format_when_logging_warn_should_log_message_as_warn()
        {
            Action<ElmahLog> action = (log) => log.WarnFormat(Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Warn);

            Assert(action, assertion);
        }

        [Test]
        public void given_message_provider_when_logging_error_should_log_message_as_error()
        {
            _action = (log, provider, message, exception) => log.Error(provider);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Error);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_object_when_logging_error_should_log_message_as_error()
        {
            _action = (log, provider, message, exception) => log.Error(message);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Error);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_object_and_exception_when_logging_error_should_log_message_and_exception_as_error()
        {
            _action = (log, provider, message, exception) => log.Error(message, exception);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Error, exception);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_format_provider_and_format_when_logging_error_should_log_message_as_error()
        {
            Action<ElmahLog> action = (log) => log.ErrorFormat(ElmahLog.DefaultFormatProvider, Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Error);

            Assert(action, assertion);
        }

        [Test]
        public void given_format_when_logging_error_should_log_message_as_error()
        {
            Action<ElmahLog> action = (log) => log.ErrorFormat(Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Error);

            Assert(action, assertion);
        }

        [Test]
        public void given_message_provider_when_logging_fatal_should_log_message_as_fatal()
        {
            _action = (log, provider, message, exception) => log.Fatal(provider);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Fatal);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_object_when_logging_fatal_should_log_message_as_fatal()
        {
            _action = (log, provider, message, exception) => log.Fatal(message);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Fatal);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_object_and_exception_when_logging_fatal_should_log_message_and_exception_as_fatal()
        {
            _action = (log, provider, message, exception) => log.Fatal(message, exception);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Fatal, exception);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_format_provider_and_format_when_logging_fatal_should_log_message_as_fatal()
        {
            Action<ElmahLog> action = (log) => log.FatalFormat(ElmahLog.DefaultFormatProvider, Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Fatal);

            Assert(action, assertion);
        }

        [Test]
        public void given_format_when_logging_fatal_should_log_message_as_fatal()
        {
            Action<ElmahLog> action = (log) => log.FatalFormat(Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Fatal);

            Assert(action, assertion);
        }

        [Test]
        public void given_message_provider_and_log_level_when_logging_should_log_message_with_log_level()
        {
            _action = (log, provider, message, exception) => log.Log(LogLevel.Debug, provider);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Debug);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_object_and_log_level_when_logging_should_log_message_with_log_level()
        {
            _action = (log, provider, message, exception) => log.Log(LogLevel.Debug, message);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Debug);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_object_and_exception_and_log_level_when_logging_should_log_message_and_exception_with_log_level()
        {
            _action = (log, provider, message, exception) => log.Log(LogLevel.Debug, message, exception);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Debug, exception);

            Assert(_action, _assertion);
        }

        [Test]
        public void given_format_provider_and_format_when_logging_should_log_message_with_log_level()
        {
            Action<ElmahLog> action = (log) => log.LogFormat(LogLevel.Debug, ElmahLog.DefaultFormatProvider, Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Debug);

            Assert(action, assertion);
        }

        [Test]
        public void given_format_when_logging_should_log_message_with_log_level()
        {
            Action<ElmahLog> action = (log) => log.LogFormat(LogLevel.Debug, Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Debug);

            Assert(action, assertion);
        }

        public void Assert(Action<ElmahLog> action, Action<Error> assertion)
        {
            var errorLog = new MemoryErrorLog();
            var log = new ElmahLog(errorLog);

            action(log);
            assertion(errorLog.GetFirstError());
        }

        public void Assert(Action<ElmahLog, LogOutputProvider, string, Exception> action, Action<Error, string, Exception> assertion)
        {
            var errorLog = new MemoryErrorLog();
            var log = new ElmahLog(errorLog);

            const string message = "test message";
            LogOutputProvider provider = () => message;
            var exception = new ArgumentException();
            action(log, provider, message, exception);

            assertion(errorLog.GetFirstError(), message, exception);
        }
    }
}
