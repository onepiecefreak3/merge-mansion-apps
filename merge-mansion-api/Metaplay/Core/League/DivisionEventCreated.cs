using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.League
{
    [LeaguesEnabledCondition]
    [AnalyticsEvent(1300, null, 1, "Division was created. At this point there are 0 participants in the division.", true, true, false)]
    public class DivisionEventCreated : DivisionEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DivisionIndex DivisionIndex { get; set; }
        public override string EventDescription { get; }

        private DivisionEventCreated()
        {
        }

        public DivisionEventCreated(DivisionIndex divisionIndex)
        {
        }
    }
}