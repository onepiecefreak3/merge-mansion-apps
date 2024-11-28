using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.MultiplayerEntity.Messages
{
    [MetaSerializable]
    public class EntityInitialState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EntitySerializedState State { get; set; } // 0x10

        [MetaMember(2, (MetaMemberFlags)0)]
        public int ChannelId { get; set; } // 0x60

        [MetaMember(3, (MetaMemberFlags)0)]
        public EntityClientData ClientData { get; set; }

        private EntityInitialState()
        {
        }

        public EntityInitialState(EntitySerializedState state, int channelId, EntityClientData clientData)
        {
            State = state;
            ChannelId = channelId;
            ClientData = clientData;
        }
    }
}