namespace MassTransit.ElmahIntegration.Tests.Logging
{
    using System;
    using Elmah;
    using NUnit.Framework;
    using MassTransit.Logging;

    public static class ErrorExtensions
    {
        public static void ShouldContain(this Error error, string message, LogLevel level, Exception exception = null)
        {
            Assert.That(error.Message, Is.EqualTo(message));
            Assert.That(error.Type, Is.EqualTo(level.ToString()));
            if (exception != null)
                Assert.That(error.Exception, Is.EqualTo(exception));
        }
    }
}
