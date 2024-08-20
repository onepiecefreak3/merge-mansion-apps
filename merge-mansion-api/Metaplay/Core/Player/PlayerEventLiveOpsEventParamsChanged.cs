using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;
using Metaplay.Core.Schedule;
using Metaplay.Core.LiveOpsEvent;

namespace Metaplay.Core.Player
{
    [AnalyticsEvent(1403, "LiveOps Event Parameters Changed", 1, "The parameters of a LiveOps Event were changed via the LiveOps Dashboard.", true, true, false)]
    public class PlayerEventLiveOpsEventParamsChanged : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaGuid EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int EditVersion { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaDuration UtcOffset { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MetaScheduleTimeMode TimeMode { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public MetaTime? StartTime { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public MetaTime? EndTime { get; set; }
        public override string EventDescription { get; }

        private PlayerEventLiveOpsEventParamsChanged()
        {
        }

        public PlayerEventLiveOpsEventParamsChanged(MetaGuid eventId, string displayName, int editVersion, MetaDuration utcOffset, MetaScheduleTimeMode timeMode, LiveOpsEventScheduleInfo scheduleForPlayerMaybe)
        {
        }
    }
}