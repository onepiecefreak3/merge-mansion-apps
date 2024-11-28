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
        [ServerOnly]
        [MetaMember(1, (MetaMemberFlags)0)]
        public EntityId GuildId { get; set; }

        [ServerOnly]
        [MetaMember(2, (MetaMemberFlags)0)]
        public GuildCreationParamsBase PendingGuildCreation { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [ServerOnly]
        public int LastPendingGuildOpEpoch { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        [ServerOnly]
        public Dictionary<int, GuildMemberGuildOpLogEntry> PendingGuildOps { get; set; }

        [ServerOnly]
        [MetaMember(5, (MetaMemberFlags)0)]
        public int LastPlayerOpEpoch { get; set; }

        [ServerOnly]
        [MetaMember(6, (MetaMemberFlags)0)]
        public int GuildMemberInstanceId { get; set; }

        public PlayerGuildStateCore()
        {
        }
    }
}