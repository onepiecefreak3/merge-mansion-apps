using Metaplay.Core.Analytics;
using Metaplay.Core.EventLog;

namespace Metaplay.Core.Player
{
    [AnalyticsEventCategory("Player")]
    public abstract class PlayerEventBase : EntityEventBase
    {
        protected PlayerEventBase()
        {
        }
    }
}