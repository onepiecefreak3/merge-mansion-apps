using Metaplay.Core.Model;
using Metaplay.Core.Guild;
using System;
using System.Collections.Generic;

namespace Metaplay.Core.Player
{
    [MetaReservedMembers(1, 100)]
    [MetaSerializable]
    public class PlayerGuildStateCore : IPlayerGuildState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [ServerOnly]
        public EntityId GuildId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [ServerOnly]
        public GuildCreationParamsBase PendingGuildCreation { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [ServerOnly]
        public int LastPendingGuildOpEpoch { get; set; }

        [ExcludeFromGdprExport]
        [ServerOnly]
        [MetaMember(4, (MetaMemberFlags)0)]
        public Dictionary<int, GuildMemberGuildOpLogEntry> PendingGuildOps { get; set; }

        [ServerOnly]
        [MetaMember(5, (MetaMemberFlags)0)]
        public int LastPlayerOpEpoch { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [ServerOnly]
        public int GuildMemberInstanceId { get; set; }

        public PlayerGuildStateCore()
        {
        }
    }
}