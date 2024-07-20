using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.GuildDiscovery
{
    [MetaSerializable]
    [MetaReservedMembers(1, 100)]
    public abstract class GuildDiscoveryInfoBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EntityId GuildId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public string DisplayName;
        [MetaMember(3, (MetaMemberFlags)0)]
        public int NumMembers;
        [MetaMember(4, (MetaMemberFlags)0)]
        public int MaxNumMembers;
        public GuildDiscoveryInfoBase()
        {
        }

        protected GuildDiscoveryInfoBase(EntityId guildId, string displayName, int numMembers, int maxNumMembers)
        {
        }
    }
}