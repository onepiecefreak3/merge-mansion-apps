using System.Collections.Generic;
using Metaplay.GameLogic.Codex;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;
using Newtonsoft.Json;

namespace Metaplay.GameLogic.MergeChains
{
    public class MergeChainDefinition : IGameConfigData<MergeChainId>
    {
        [MetaMember(1, 0)]
        public MergeChainId ConfigKey { get; set; }
        [MetaMember(2, 0)]
        public List<IMergeChainElement> PrimaryChain { get; set; }
        [MetaMember(3, 0)]
        public List<IMergeChainElement> FallbackChain { get; set; }
        [MetaMember(4, 0)]
        public MetaRef<CodexCategoryInfo> CodexCategory { get; set; }
        [MetaMember(5, 0)]
        public MetaRef<CodexDiscoveryRewardInfo> DiscoveryRewardRef { get; set; }
	}
}
