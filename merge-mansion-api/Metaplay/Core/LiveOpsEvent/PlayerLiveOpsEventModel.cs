using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.LiveOpsEvent
{
    [MetaReservedMembers(100, 200)]
    [MetaSerializable]
    public abstract class PlayerLiveOpsEventModel : IMetaIntegration<PlayerLiveOpsEventModel>, IMetaIntegration
    {
        [MetaMember(102, (MetaMemberFlags)0)]
        private LiveOpsEventContent _content;
        [MetaMember(100, (MetaMemberFlags)0)]
        public MetaGuid Id { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        public LiveOpsEventScheduleInfo ScheduleMaybe { get; set; }

        [MetaMember(103, (MetaMemberFlags)0)]
        public LiveOpsEventPhase Phase { get; set; }
        public LiveOpsEventContent Content { get; set; }

        protected PlayerLiveOpsEventModel()
        {
        }

        protected PlayerLiveOpsEventModel(IPlayerLiveOpsEventInfo info)
        {
        }

        [MetaMember(104, (MetaMemberFlags)0)]
        public MetaTime? LatestUnacknowledgedUpdate { get; set; }

        [MetaMember(105, (MetaMemberFlags)0)]
        public bool PlayerIsInTargetAudience { get; set; }
        public virtual bool AllowRemove { get; }

        protected PlayerLiveOpsEventModel(PlayerLiveOpsEventInfo info)
        {
        }
    }
}