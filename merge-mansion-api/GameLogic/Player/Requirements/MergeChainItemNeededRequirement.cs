using System;
using GameLogic.MergeChains;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(12)]
    public class MergeChainItemNeededRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaRef<MergeChainDefinition> MergeChainRef { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int? MinLevel { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int? MaxLevel { get; set; }
        private MergeChainDefinition MergeChain { get; }

        private MergeChainItemNeededRequirement()
        {
        }

        public MergeChainItemNeededRequirement(MetaRef<MergeChainDefinition> mergeChain, int? minLevel, int? maxLevel)
        {
        }
    }
}