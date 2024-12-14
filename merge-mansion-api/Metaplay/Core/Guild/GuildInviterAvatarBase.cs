using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Guild
{
    [MetaSerializable]
    [MetaReservedMembers(1, 100)]
    public abstract class GuildInviterAvatarBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EntityId PlayerId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        protected GuildInviterAvatarBase()
        {
        }
    }
}