using Metaplay.Core.Model;
using Metaplay.Core.Client;

namespace Metaplay.Core.MultiplayerEntity.Messages
{
    [MetaSerializable]
    [MetaReservedMembers(100, 200)]
    public abstract class EntityClientData
    {
        [MetaMember(101, (MetaMemberFlags)0)]
        public ClientSlot ClientSlot { get; set; }

        protected EntityClientData()
        {
        }

        protected EntityClientData(ClientSlot clientSlot)
        {
        }

        [MetaSerializableDerived(101)]
        public class Default : EntityClientData
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