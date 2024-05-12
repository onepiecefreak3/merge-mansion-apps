using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace Metaplay.Core.LiveOpsEvent
{
    [ModelAction(10300)]
    public class PlayerAddLiveOpsEvent : PlayerSynchronizedServerActionCore<IPlayerModelBase>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaGuid EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public LiveOpsEventScheduleOccasion ScheduleMaybe { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public LiveOpsEventContent Content { get; set; }

        private PlayerAddLiveOpsEvent()
        {
        }

        public PlayerAddLiveOpsEvent(MetaGuid eventId, LiveOpsEventScheduleOccasion scheduleMaybe, LiveOpsEventContent content)
        {
        }
    }
}