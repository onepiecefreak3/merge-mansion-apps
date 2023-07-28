using Metaplay.Core.Client;
using Metaplay.Core.Model;

namespace Metaplay.Core.MultiplayerEntity.Messages
{
    [MetaSerializable]
    public abstract class ChannelContextDataBase
    {
        [MetaMember(101, 0)]
        public ClientSlot ClientSlot { get; set; }
    }
}
