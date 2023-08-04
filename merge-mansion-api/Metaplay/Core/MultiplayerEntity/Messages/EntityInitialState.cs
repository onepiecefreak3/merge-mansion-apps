using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.MultiplayerEntity.Messages
{
    [MetaSerializable]
    public class EntityInitialState
    {
        [MetaMember(1, 0)]
        public EntitySerializedState State { get; set; } // 0x10

        [MetaMember(2, 0)]
        public int ChannelId { get; set; } // 0x60

        [MetaMember(3, 0)]
        public ChannelContextDataBase ContextData { get; set; } // 0x68

        private EntityInitialState()
        {
        }

        public EntityInitialState(EntitySerializedState state, int channelId, ChannelContextDataBase contextData)
        {
            State = state;
            ChannelId = channelId;
            ContextData = contextData;
        }
    }
}