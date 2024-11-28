using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Metaplay.Core.Guild
{
    [MetaReservedMembers(1, 100)]
    [MetaSerializable]
    public abstract class GuildMemberBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [Transient]
        public bool IsOnline;
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime LastOnlineAt;
        [MetaMember(3, (MetaMemberFlags)0)]
        public string DisplayName;
        [MetaMember(4, (MetaMemberFlags)0)]
        [ServerOnly]
        public int LastGuildOpEpoch;
        [MetaMember(5, (MetaMemberFlags)0)]
        [ServerOnly]
        public int LastPendingPlayerOpEpoch;
        [ExcludeFromGdprExport]
        [MetaMember(6, (MetaMemberFlags)0)]
        [ServerOnly]
        public Dictionary<int, GuildMemberPlayerOpLogEntry> PendingPlayerOps;
        [MetaMember(7, (MetaMemberFlags)0)]
        public int MemberInstanceId;
        [MetaMember(8, (MetaMemberFlags)0)]
        public GuildMemberRole Role;
        [MetaMember(9, (MetaMemberFlags)0)]
        [ServerOnly]
        public Dictionary<int, GuildInviteState> Invites;
        [IgnoreDataMember]
        public virtual int MaxNumInvites { get; }
        public EntityId PlayerId { get; set; }

        public GuildMemberBase()
        {
        }

        public GuildMemberBase(int memberInstanceId, GuildMemberRole role, EntityId playerId)
        {
        }
    }
}