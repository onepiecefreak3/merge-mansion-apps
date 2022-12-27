using Metaplay.Metaplay.Core.Client;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.MultiplayerEntity.Messages
{
    public abstract class ChannelContextDataBase
    {
        [MetaMember(101, 0)]
        public ClientSlot ClientSlot { get; set; }
    }
}
