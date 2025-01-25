using Metaplay.Core.Model;
using Metaplay.Core.MultiplayerEntity.Messages;
using Metaplay.Core.Client;

namespace Metaplay.Core.League.Messages
{
    [MetaReservedMembers(200, 300)]
    [MetaSerializableDerived(102)]
    [LeaguesEnabledCondition]
    public class DivisionEntityClientData : EntityClientData
    {
        [MetaMember(201, (MetaMemberFlags)0)]
        public EntityId ParticipantId { get; set; }

        private DivisionEntityClientData()
        {
        }

        public DivisionEntityClientData(ClientSlot clientSlot, EntityId participantId)
        {
        }
    }
}