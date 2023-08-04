namespace Metaplay.Core.Analytics
{
    [AnalyticsEventCategory("Client")]
    public abstract class ClientEventBase : AnalyticsEventBase
    {
        protected ClientEventBase()
        {
        }
    }
}