using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace Metaplay.Core.Guild
{
    [MetaSerializable]
    public class GuildPendingMemberKickState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime IssuedAt;
        [MetaMember(2, (MetaMemberFlags)0)]
        public IGuildMemberKickReason ReasonOrNull;
        [MetaMember(3, (MetaMemberFlags)0)]
        public Dictionary<int, GuildMemberPlayerOpLogEntry> PendingPlayerOps;
        [MetaMember(4, (MetaMemberFlags)0)]
        public int MemberInstanceId;
        public GuildPendingMemberKickState()
        {
        }

        public GuildPendingMemberKickState(MetaTime issuedAt, IGuildMemberKickReason reasonOrNull, Dictionary<int, GuildMemberPlayerOpLogEntry> pendingPlayerOps, int memberInstanceId)
        {
        }
    }
}