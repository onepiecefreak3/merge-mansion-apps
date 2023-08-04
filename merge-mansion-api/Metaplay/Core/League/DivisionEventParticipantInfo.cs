using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.League
{
    [MetaSerializable]
    [LeaguesEnabledCondition]
    public struct DivisionEventParticipantInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EntityId ParticipantId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }
    }
}