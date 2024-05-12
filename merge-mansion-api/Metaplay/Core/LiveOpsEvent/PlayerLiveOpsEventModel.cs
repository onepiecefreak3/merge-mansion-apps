using Metaplay.Core.Model;

namespace Metaplay.Core.LiveOpsEvent
{
    [MetaSerializable]
    [MetaReservedMembers(100, 200)]
    public abstract class PlayerLiveOpsEventModel
    {
        [MetaMember(102, (MetaMemberFlags)0)]
        private LiveOpsEventContent _content;
        [MetaMember(100, (MetaMemberFlags)0)]
        public MetaGuid Id { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        public LiveOpsEventScheduleOccasion ScheduleMaybe { get; set; }

        [MetaMember(103, (MetaMemberFlags)0)]
        public LiveOpsEventPhase Phase { get; set; }
        public LiveOpsEventContent Content { get; set; }

        protected PlayerLiveOpsEventModel()
        {
        }

        protected PlayerLiveOpsEventModel(IPlayerLiveOpsEventInfo info)
        {
        }
    }
}