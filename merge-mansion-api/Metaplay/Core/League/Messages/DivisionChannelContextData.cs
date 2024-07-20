using Metaplay.Core.Model;
using Metaplay.Core.MultiplayerEntity.Messages;
using Metaplay.Core.Client;

namespace Metaplay.Core.League.Messages
{
    [LeaguesEnabledCondition]
    [MetaReservedMembers(200, 300)]
    [MetaSerializableDerived(102)]
    public class DivisionChannelContextData : ChannelContextDataBase
    {
        [MetaMember(201, (MetaMemberFlags)0)]
        public EntityId ParticipantId { get; set; }

        private DivisionChannelContextData()
        {
        }

        public DivisionChannelContextData(ClientSlot clientSlot, EntityId participantId)
        {
        }
    }
}