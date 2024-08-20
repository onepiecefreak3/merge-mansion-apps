using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Player
{
    [AnalyticsEvent(1402, "LiveOps Event Audience Membership Changed", 1, "A player entered or left the segmentation-based target audience of a LiveOps Event while the event was already active. Note that leaving the target audience does not automatically disable the event; the audience membership changes are simply communicated to game code.", true, true, false)]
    public class PlayerEventLiveOpsEventAudienceMembershipChanged : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaGuid EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public bool PlayerIsInTargetAudience { get; set; }
        public override string EventDescription { get; }

        private PlayerEventLiveOpsEventAudienceMembershipChanged()
        {
        }

        public PlayerEventLiveOpsEventAudienceMembershipChanged(MetaGuid eventId, string displayName, bool playerIsInTargetAudience)
        {
        }
    }
}