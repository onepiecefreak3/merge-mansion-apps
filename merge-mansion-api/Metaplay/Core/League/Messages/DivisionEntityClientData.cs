using Metaplay.Core.Model;
using Metaplay.Core.MultiplayerEntity.Messages;
using Metaplay.Core.Client;

namespace Metaplay.Core.League.Messages
{
    [MetaSerializableDerived(102)]
    [MetaReservedMembers(200, 300)]
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