using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.LiveOpsEvent
{
    [MetaSerializable]
    public class PlayerLiveOpsEventServerOnlyModel
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaGuid EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public LiveOpsEventPhase LatestAssignedPhase { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int EditVersion { get; set; }

        private PlayerLiveOpsEventServerOnlyModel()
        {
        }

        public PlayerLiveOpsEventServerOnlyModel(MetaGuid eventId, LiveOpsEventPhase latestAssignedPhase, int editVersion)
        {
        }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaDuration PlayerUtcOffsetForEvent { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool PlayerIsInTargetAudience { get; set; }

        public PlayerLiveOpsEventServerOnlyModel(MetaGuid eventId, MetaDuration playerUtcOffsetForEvent, LiveOpsEventPhase latestAssignedPhase, int editVersion, bool playerIsInTargetAudience)
        {
        }
    }
}