using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System.Collections.Generic;

namespace Metaplay.Core.LiveOpsEvent
{
    [ModelAction(10300)]
    public class PlayerAddLiveOpsEvent : PlayerSynchronizedServerActionCore<IPlayerModelBase>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaGuid EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public LiveOpsEventScheduleInfo ScheduleMaybe { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public LiveOpsEventContent Content { get; set; }

        private PlayerAddLiveOpsEvent()
        {
        }

        public PlayerAddLiveOpsEvent(MetaGuid eventId, LiveOpsEventScheduleOccasion scheduleMaybe, LiveOpsEventContent content)
        {
        }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<LiveOpsEventPhase> FastForwardedPhases { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public LiveOpsEventPhase Phase { get; set; }

        public PlayerAddLiveOpsEvent(MetaGuid eventId, LiveOpsEventScheduleInfo scheduleMaybe, LiveOpsEventContent content, List<LiveOpsEventPhase> fastForwardedPhases, LiveOpsEventPhase phase)
        {
        }
    }
}