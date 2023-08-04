using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Guild
{
    [MetaSerializable]
    public struct GuildEventMemberInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EntityId PlayerId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int MemberInstanceId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }
    }
}