using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace Metaplay.Core.LiveOpsEvent
{
    [ModelAction(10303)]
    public class PlayerForceSetLiveOpsEventInfo : PlayerSynchronizedServerActionCore<IPlayerModelBase>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaGuid EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public LiveOpsEventScheduleOccasion NewScheduleMaybe { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public LiveOpsEventContent NewContent { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public LiveOpsEventPhase NewPhase { get; set; }

        private PlayerForceSetLiveOpsEventInfo()
        {
        }

        public PlayerForceSetLiveOpsEventInfo(MetaGuid eventId, LiveOpsEventScheduleOccasion newScheduleMaybe, LiveOpsEventContent newContent, LiveOpsEventPhase newPhase)
        {
        }
    }
}