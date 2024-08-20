using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Guild
{
    [MetaSerializable]
    [MetaReservedMembers(1, 100)]
    public abstract class GuildCreationParamsBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string Description { get; set; }

        protected GuildCreationParamsBase()
        {
        }
    }
}