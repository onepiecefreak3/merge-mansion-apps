using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Guild
{
    [MetaReservedMembers(1, 100)]
    [MetaSerializable]
    public abstract class GuildMemberPlayerDataBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        public GuildMemberPlayerDataBase()
        {
        }

        protected GuildMemberPlayerDataBase(string displayName)
        {
        }
    }
}