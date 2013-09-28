namespace MassTransit.ElmahIntegration.Logging
{
    using Elmah;
    using MassTransit.Logging;

    public class ElmahLogger :
        ILogger
    {
        public ILog Get(string name)
        {
            return new ElmahLog(ErrorLog.GetDefault(null));
        }

        public static void Use()
        {
            Logger.UseLogger(new ElmahLogger());
        }
    }
}
