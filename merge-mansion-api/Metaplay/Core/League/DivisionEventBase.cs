using Metaplay.Core.Analytics;
using Metaplay.Core.EventLog;

namespace Metaplay.Core.League
{
    [AnalyticsEventCategory("Division")]
    public abstract class DivisionEventBase : EntityEventBase
    {
        protected DivisionEventBase()
        {
        }
    }
}