using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace Metaplay.Core.LiveOpsEvent
{
    [ModelAction(10302)]
    public class PlayerUpdateEventLiveOpsEventParams : PlayerSynchronizedServerActionCore<IPlayerModelBase>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaGuid EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public LiveOpsEventScheduleOccasion ScheduleMaybe { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public LiveOpsEventContent Content { get; set; }

        private PlayerUpdateEventLiveOpsEventParams()
        {
        }

        public PlayerUpdateEventLiveOpsEventParams(MetaGuid eventId, LiveOpsEventScheduleOccasion scheduleMaybe, LiveOpsEventContent content)
        {
        }

        public PlayerUpdateEventLiveOpsEventParams(MetaGuid eventId, LiveOpsEventScheduleInfo scheduleMaybe, LiveOpsEventContent content)
        {
        }
    }
}