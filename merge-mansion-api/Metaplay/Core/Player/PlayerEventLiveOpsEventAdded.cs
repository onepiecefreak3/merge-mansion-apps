using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;
using Metaplay.Core.Schedule;
using System.Collections.Generic;
using Metaplay.Core.LiveOpsEvent;

namespace Metaplay.Core.Player
{
    [AnalyticsEvent(1400, "Joined LiveOps Event", 1, "The player joined a LiveOps Event. It is possible to join an event while it's already underway.", true, true, false)]
    public class PlayerEventLiveOpsEventAdded : PlayerEventBase
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

        [FirebaseAnalyticsIgnore]
        [MetaMember(8, (MetaMemberFlags)0)]
        public List<string> FastForwardedPhases { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public string Phase { get; set; }
        public override string EventDescription { get; }

        private PlayerEventLiveOpsEventAdded()
        {
        }

        public PlayerEventLiveOpsEventAdded(MetaGuid eventId, string displayName, int editVersion, MetaDuration utcOffset, MetaScheduleTimeMode timeMode, LiveOpsEventScheduleInfo scheduleForPlayerMaybe, List<LiveOpsEventPhase> fastForwardedPhases, LiveOpsEventPhase phase)
        {
        }
    }
}