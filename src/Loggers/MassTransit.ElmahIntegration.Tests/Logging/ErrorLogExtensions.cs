namespace MassTransit.ElmahIntegration.Tests.Logging
{
    using System.Collections.Generic;
    using Elmah;

    public static class ErrorLogExtensions
    {
        public static Error GetFirstError(this ErrorLog errorLog)
        {
            var page = new List<ErrorLogEntry>();
            errorLog.GetErrors(0, int.MaxValue, page);
            return page[0].Error;
        }
    }
}
