using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Guild
{
    [MetaSerializable]
    [MetaReservedMembers(1, 100)]
    public abstract class GuildSearchParamsBase : IMetaIntegrationConstructible<GuildSearchParamsBase>, IMetaIntegration<GuildSearchParamsBase>, IMetaIntegration, IMetaIntegrationConstructible, IRequireSingleConcreteType
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string SearchString { get; set; }

        public GuildSearchParamsBase()
        {
        }

        protected GuildSearchParamsBase(string searchString)
        {
        }
    }
}