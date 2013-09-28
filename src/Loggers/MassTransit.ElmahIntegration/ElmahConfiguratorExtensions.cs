namespace MassTransit.ElmahIntegration
{
    using BusConfigurators;
    using Logging;
    using Util;

    public static class ElmahConfiguratorExtensions
    {
        /// <summary>
        /// Specify that you want to use the Elmah logging framework with MassTransit.
        /// </summary>
        /// <param name="configurator">Optional service bus configurator</param>
        public static void UseElmah([CanBeNull] this ServiceBusConfigurator configurator)
        {
            ElmahLogger.Use();
        }
    }
}
