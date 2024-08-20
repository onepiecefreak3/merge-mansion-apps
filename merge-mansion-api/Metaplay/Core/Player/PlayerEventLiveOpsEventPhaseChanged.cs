using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using Metaplay.Core.LiveOpsEvent;

namespace Metaplay.Core.Player
{
    [AnalyticsEvent(1401, "LiveOps Event Phase Advanced", 1, "A LiveOps Event has advanced to a new phase (preview, active, review, ...). An event with player-local scheduling can be in different phases for different players.", true, true, false)]
    public class PlayerEventLiveOpsEventPhaseChanged : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaGuid EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [FirebaseAnalyticsIgnore]
        [MetaMember(3, (MetaMemberFlags)0)]
        public List<string> FastForwardedPhases { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string Phase { get; set; }
        public override string EventDescription { get; }

        private PlayerEventLiveOpsEventPhaseChanged()
        {
        }

        public PlayerEventLiveOpsEventPhaseChanged(MetaGuid eventId, string displayName, List<LiveOpsEventPhase> fastForwardedPhases, LiveOpsEventPhase phase)
        {
        }
    }
}