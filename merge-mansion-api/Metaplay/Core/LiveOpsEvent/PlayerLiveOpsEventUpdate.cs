using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.LiveOpsEvent
{
    [MetaSerializable]
    public class PlayerLiveOpsEventUpdate
    {
        [MetaMember(5, (MetaMemberFlags)0)]
        public PlayerLiveOpsEventUpdateType Type;
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime Timestamp;
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaGuid EventId;
        [MetaMember(3, (MetaMemberFlags)0)]
        public PlayerLiveOpsEventModel EventModel;
        [MetaMember(4, (MetaMemberFlags)0)]
        public bool IsNewEvent;
        [MetaMember(6, (MetaMemberFlags)0)]
        public LiveOpsEventPhase[] FastForwardedPhases;
        public PlayerLiveOpsEventUpdate()
        {
        }
    }
}