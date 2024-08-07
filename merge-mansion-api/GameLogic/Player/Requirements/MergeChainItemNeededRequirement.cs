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

        [MetaMember(2, 0)]
        public Nullable<int> MinLevel { get; set; }

        [MetaMember(3, 0)]
        public Nullable<int> MaxLevel { get; set; }
        private MergeChainDefinition MergeChain { get; }

        private MergeChainItemNeededRequirement()
        {
        }

        public MergeChainItemNeededRequirement(MetaRef<MergeChainDefinition> mergeChain, int? minLevel, int? maxLevel)
        {
        }
    }
}