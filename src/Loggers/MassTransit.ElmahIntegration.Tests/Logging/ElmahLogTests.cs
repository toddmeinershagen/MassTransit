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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Elmah;
    using ElmahIntegration.Logging;
    using MassTransit.Logging;
    using NUnit.Framework;

    [TestFixture]
    public class given_minimum_log_level_of_all
    {
        Action<ElmahLog, LogOutputProvider, string, Exception> _action;
        Action<Error, string, Exception> _assertion;
        const string Format = "You are number {0}, {1}.";
        const string FormattedMessage = "You are number 1, Tammy.";
        readonly object[] _args = { 1, "Tammy" };
        readonly LogLevel _minimumLevel = LogLevel.All;
        private readonly MemoryErrorLog _errorLog = new MemoryErrorLog(1);

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

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_object_when_logging_debug_should_log_message_as_debug()
        {
            _action = (log, provider, message, exception) => log.Debug(message);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Debug);

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_object_and_exception_when_logging_debug_should_log_message_and_exception_as_debug()
        {
            _action = (log, provider, message, exception) => log.Debug(message, exception);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Debug, exception);

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_format_provider_and_format_when_logging_debug_should_log_message_as_debug()
        {
            Action<ElmahLog> action = (log) => log.DebugFormat(ElmahLog.DefaultFormatProvider, Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Debug);

            ActAndAssert(action, assertion);
        }

        [Test]
        public void given_format_when_logging_debug_should_log_message_as_debug()
        {
            Action<ElmahLog> action = (log) => log.DebugFormat(Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Debug);

            ActAndAssert(action, assertion);
        }

        [Test]
        public void given_message_provider_when_logging_info_should_log_message_as_info()
        {
            _action = (log, provider, message, exception) => log.Info(provider);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Info);

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_object_when_logging_info_should_log_message_as_info()
        {
            _action = (log, provider, message, exception) => log.Info(message);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Info);

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_object_and_exception_when_logging_info_should_log_message_and_exception_as_info()
        {
            _action = (log, provider, message, exception) => log.Info(message, exception);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Info, exception);

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_format_provider_and_format_when_logging_info_should_log_message_as_info()
        {
            Action<ElmahLog> action = (log) => log.InfoFormat(ElmahLog.DefaultFormatProvider, Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Info);

            ActAndAssert(action, assertion);
        }

        [Test]
        public void given_format_when_logging_info_should_log_message_as_info()
        {
            Action<ElmahLog> action = (log) => log.InfoFormat(Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Info);

            ActAndAssert(action, assertion);
        }

        [Test]
        public void given_message_provider_when_logging_warning_should_log_message_as_warning()
        {
            _action = (log, provider, message, exception) => log.Warn(provider);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Warn);

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_object_when_logging_warning_should_log_message_as_warning()
        {
            _action = (log, provider, message, exception) => log.Warn(message);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Warn);

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_object_and_exception_when_logging_debug_should_warning_message_and_exception_as_warning()
        {
            _action = (log, provider, message, exception) => log.Warn(message, exception);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Warn, exception);

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_format_provider_and_format_when_logging_warning_should_log_message_as_warning()
        {
            Action<ElmahLog> action = (log) => log.WarnFormat(ElmahLog.DefaultFormatProvider, Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Warn);

            ActAndAssert(action, assertion);
        }

        [Test]
        public void given_format_when_logging_warn_should_log_message_as_warn()
        {
            Action<ElmahLog> action = (log) => log.WarnFormat(Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Warn);

            ActAndAssert(action, assertion);
        }

        [Test]
        public void given_message_provider_when_logging_error_should_log_message_as_error()
        {
            _action = (log, provider, message, exception) => log.Error(provider);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Error);

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_object_when_logging_error_should_log_message_as_error()
        {
            _action = (log, provider, message, exception) => log.Error(message);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Error);

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_object_and_exception_when_logging_error_should_log_message_and_exception_as_error()
        {
            _action = (log, provider, message, exception) => log.Error(message, exception);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Error, exception);

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_format_provider_and_format_when_logging_error_should_log_message_as_error()
        {
            Action<ElmahLog> action = (log) => log.ErrorFormat(ElmahLog.DefaultFormatProvider, Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Error);

            ActAndAssert(action, assertion);
        }

        [Test]
        public void given_format_when_logging_error_should_log_message_as_error()
        {
            Action<ElmahLog> action = (log) => log.ErrorFormat(Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Error);

            ActAndAssert(action, assertion);
        }

        [Test]
        public void given_message_provider_when_logging_fatal_should_log_message_as_fatal()
        {
            _action = (log, provider, message, exception) => log.Fatal(provider);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Fatal);

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_object_when_logging_fatal_should_log_message_as_fatal()
        {
            _action = (log, provider, message, exception) => log.Fatal(message);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Fatal);

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_object_and_exception_when_logging_fatal_should_log_message_and_exception_as_fatal()
        {
            _action = (log, provider, message, exception) => log.Fatal(message, exception);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Fatal, exception);

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_format_provider_and_format_when_logging_fatal_should_log_message_as_fatal()
        {
            Action<ElmahLog> action = (log) => log.FatalFormat(ElmahLog.DefaultFormatProvider, Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Fatal);

            ActAndAssert(action, assertion);
        }

        [Test]
        public void given_format_when_logging_fatal_should_log_message_as_fatal()
        {
            Action<ElmahLog> action = (log) => log.FatalFormat(Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Fatal);

            ActAndAssert(action, assertion);
        }

        [Test]
        public void given_message_provider_and_log_level_when_logging_should_log_message_with_log_level()
        {
            _action = (log, provider, message, exception) => log.Log(LogLevel.Debug, provider);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Debug);

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_object_and_log_level_when_logging_should_log_message_with_log_level()
        {
            _action = (log, provider, message, exception) => log.Log(LogLevel.Debug, message);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Debug);

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_object_and_exception_and_log_level_when_logging_should_log_message_and_exception_with_log_level()
        {
            _action = (log, provider, message, exception) => log.Log(LogLevel.Debug, message, exception);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Debug, exception);

            ActAndAssert(_action, _assertion);
        }

        [Test]
        public void given_format_provider_and_format_when_logging_should_log_message_with_log_level()
        {
            Action<ElmahLog> action = (log) => log.LogFormat(LogLevel.Debug, ElmahLog.DefaultFormatProvider, Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Debug);

            ActAndAssert(action, assertion);
        }

        [Test]
        public void given_format_when_logging_should_log_message_with_log_level()
        {
            Action<ElmahLog> action = (log) => log.LogFormat(LogLevel.Debug, Format, _args);
            Action<Error> assertion = (error) => error.ShouldContain(FormattedMessage, LogLevel.Debug);

            ActAndAssert(action, assertion);
        }

        public void ActAndAssert(Action<ElmahLog> action, Action<Error> assertion)
        {
            var errorLog = new MemoryErrorLog(1);
            var log = new ElmahLog(errorLog, _minimumLevel);

            action(log);
            assertion(errorLog.GetFirstError());
        }

        public void ActAndAssert(Action<ElmahLog, LogOutputProvider, string, Exception> action, Action<Error, string, Exception> assertion)
        {
            var log = new ElmahLog(_errorLog, _minimumLevel);

            const string message = "test message";
            LogOutputProvider provider = () => message;
            var exception = new ArgumentException();
            action(log, provider, message, exception);

            assertion(_errorLog.GetFirstError(), message, exception);
        }
    }

    [TestFixture]
    public class given_a_minimum_log_level
    {
        Action<ElmahLog, LogOutputProvider, string, Exception> _action;
        Action<Error, string, Exception> _assertion;
        private readonly ErrorLog _errorLog = new MemoryErrorLog(1);

        [TearDown]
        public void TearDown()
        {
            _action = null;
            _assertion = null;
        }

        [Test]
        public void given_object_and_exception_when_logging_with_level_above_minimum_level_should_log_message_and_exception_with_log_level()
        {
            _action = (log, provider, message, exception) => log.Log(LogLevel.Fatal, message, exception);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Fatal, exception);

            var minimumLevel = LogLevel.Error;
            ActAndAssert(minimumLevel, _action, _assertion);
        }

        [Test]
        public void given_object_and_exception_when_logging_with_level_equal_to_minimum_level_should_not_log_message()
        {
            _action = (log, provider, message, exception) => log.Log(LogLevel.Info, message, exception);
            _assertion = (error, message, exception) => error.ShouldContain(message, LogLevel.Info, exception);

            var minimumLevel = LogLevel.Info;
            ActAndAssert(minimumLevel, _action, _assertion);
        }

        [Test]
        public void given_object_and_exception_when_logging_with_level_below_minimum_level_should_not_log_message()
        {
            _action = (log, provider, message, exception) => log.Log(LogLevel.Info, message, exception);
            _assertion = (error, message, exception) => Assert.That(error, Is.Null);

            var minimumLevel = LogLevel.Warn;
            ActAndAssert(minimumLevel, _action, _assertion);
        }

        public void ActAndAssert(LogLevel minimumLevel, Action<ElmahLog, LogOutputProvider, string, Exception> action, Action<Error, string, Exception> assertion)
        {
            _errorLog.Clear();
            var log = new ElmahLog(_errorLog, minimumLevel);

            const string message = "test message";
            LogOutputProvider provider = () => message;
            var exception = new ArgumentException();
            action(log, provider, message, exception);

            assertion(_errorLog.GetFirstError(), message, exception);
        }
    }

    [TestFixture]
    public class ElmahLogTests
    {
        readonly MemoryErrorLog _errorLog = new MemoryErrorLog(1);

        [Test]
        public void given_minimum_log_level_of_none_is_enabled_properties_should_return_proper_values()
        {
            AssertForLogLevel(LogLevel.None, false, false, false, false, false);
        }

        [Test]
        public void given_minimum_log_level_of_fatal_is_enabled_properties_should_return_proper_values()
        {
            AssertForLogLevel(LogLevel.Fatal, false, false, true, false, false);
        }

        [Test]
        public void given_minimum_log_level_of_error_is_enabled_properties_should_return_proper_values()
        {
            AssertForLogLevel(LogLevel.Error, false, true, true, false, false);
        }

        [Test]
        public void given_minimum_log_level_of_warn_is_enabled_properties_should_return_proper_values()
        {
            AssertForLogLevel(LogLevel.Warn, false, true, true, false, true);
        }

        [Test]
        public void given_minimum_log_level_of_info_is_enabled_properties_should_return_proper_values()
        {
            AssertForLogLevel(LogLevel.Info, false, true, true, true, true);
        }

        [Test]
        public void given_minimum_log_level_of_debug_is_enabled_properties_should_return_proper_values()
        {
            AssertForLogLevel(LogLevel.Debug, true, true, true, true, true);
        }

        [Test]
        public void given_minimum_log_level_of_all_is_enabled_properties_should_return_proper_values()
        {
            AssertForLogLevel(LogLevel.All, true, true, true, true, true);
        }

        private void AssertForLogLevel(LogLevel minimumLevel, bool isDebugEnabled, bool isErrorEnabled, bool isFatalEnabled, bool isInfoEnabled, bool isWarnEnabled)
        {
            var logger = new ElmahLog(_errorLog, minimumLevel);

            Assert.That(logger.IsDebugEnabled, Is.EqualTo(isDebugEnabled), "IsDebugEnabled property");
            Assert.That(logger.IsErrorEnabled, Is.EqualTo(isErrorEnabled), "IsErrorEnabled property");
            Assert.That(logger.IsFatalEnabled, Is.EqualTo(isFatalEnabled), "IsFatalEnabled property");
            Assert.That(logger.IsInfoEnabled, Is.EqualTo(isInfoEnabled), "IsInfoEnabled property");
            Assert.That(logger.IsWarnEnabled, Is.EqualTo(isWarnEnabled), "IsWarnEnabled property");
        }
    }
}
