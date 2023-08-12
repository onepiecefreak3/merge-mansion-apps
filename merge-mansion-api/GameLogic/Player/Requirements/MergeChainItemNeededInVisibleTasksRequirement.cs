using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic.Player.Items;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(21)]
    public class MergeChainItemNeededInVisibleTasksRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> MinItemInChainRef { get; set; }

        private MergeChainItemNeededInVisibleTasksRequirement()
        {
        }

        public MergeChainItemNeededInVisibleTasksRequirement(MetaRef<ItemDefinition> minItemInChainRef)
        {
        }
    }
}