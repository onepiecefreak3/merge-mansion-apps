using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Guild
{
    [MetaSerializable]
    public class GuildInviteState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public GuildInviteType Type;
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime CreatedAt;
        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaDuration? ExpiresAfter;
        [MetaMember(4, (MetaMemberFlags)0)]
        public int NumMaxUsages;
        [MetaMember(5, (MetaMemberFlags)0)]
        public int NumTimesUsed;
        [MetaMember(6, (MetaMemberFlags)0)]
        public GuildInviteCode InviteCode;
        private GuildInviteState()
        {
        }

        public GuildInviteState(GuildInviteType type, MetaTime createdAt, MetaDuration? expiresAfter, int numMaxUsages, int numTimesUsed, GuildInviteCode inviteCode)
        {
        }
    }
}