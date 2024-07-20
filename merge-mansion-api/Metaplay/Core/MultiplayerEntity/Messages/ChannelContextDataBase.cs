using Metaplay.Core.Client;
using Metaplay.Core.Model;

namespace Metaplay.Core.MultiplayerEntity.Messages
{
    [MetaReservedMembers(100, 200)]
    [MetaSerializable]
    public abstract class ChannelContextDataBase
    {
        [MetaMember(101, (MetaMemberFlags)0)]
        public ClientSlot ClientSlot { get; set; }

        protected ChannelContextDataBase()
        {
        }

        protected ChannelContextDataBase(ClientSlot clientSlot)
        {
        }

        [MetaSerializableDerived(101)]
        public class Default : ChannelContextDataBase
        {
            private Default()
            {
            }

            public Default(ClientSlot clientSlot)
            {
            }
        }
    }
}