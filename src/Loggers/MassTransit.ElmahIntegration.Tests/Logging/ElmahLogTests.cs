
namespace MassTransit.ElmahIntegration.Tests.Logging
{
    using System.Collections.Generic;
    using Elmah;
    using ElmahIntegration.Logging;
    using MassTransit.Logging;
    using NUnit.Framework;

    [TestFixture]
    public class ElmahLogTests
    {
        [Test]
        public void given_message_provider_when_logging_debug_message_should_log_message_as_debug()
        {
            var errorLog = new MemoryErrorLog();

            var log = new ElmahLog(errorLog);

            const string expectedMessage = "test message";
            LogOutputProvider provider = () => expectedMessage;
            log.Debug(provider);

            var page1 = new List<ErrorLogEntry>();
            errorLog.GetErrors(0, 2, page1);

            Assert.That(page1[0].Error.Message, Is.EqualTo(expectedMessage));
            Assert.That(page1[0].Error.Type, Is.EqualTo(LogLevel.Debug.ToString()));
        }
    }
}
