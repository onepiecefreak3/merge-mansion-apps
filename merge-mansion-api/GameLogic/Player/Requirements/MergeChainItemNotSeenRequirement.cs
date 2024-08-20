using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic.MergeChains;
using GameLogic.Player.Items;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(46)]
    public class MergeChainItemNotSeenRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaRef<MergeChainDefinition> MergeChainRef { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> MinItemRef { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> MaxItemRef { get; set; }
        private MergeChainDefinition MergeChain { get; }
        private ItemDefinition DefaultItem { get; }

        private MergeChainItemNotSeenRequirement()
        {
        }

        public MergeChainItemNotSeenRequirement(MetaRef<MergeChainDefinition> mergeChain, MetaRef<ItemDefinition> minItemRef, MetaRef<ItemDefinition> maxItemRef)
        {
        }
    }
}