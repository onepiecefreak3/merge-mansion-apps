using Metaplay.Core.Analytics;
using Metaplay.Core.EventLog;

namespace Metaplay.Core.Guild
{
    [AnalyticsEventCategory("Guild")]
    public abstract class GuildEventBase : EntityEventBase
    {
        protected GuildEventBase()
        {
        }
    }
}