using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(3)]
    public class MysteryMachineProgressionEventProgressItem : IMysteryMachineItem
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineProgressionEventProgressItemChainId ChainId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int ChainItemIndex { get; set; }

        private MysteryMachineProgressionEventProgressItem()
        {
        }

        public MysteryMachineProgressionEventProgressItem(MysteryMachineProgressionEventProgressItemChainId chainId, int chainItemIndex)
        {
        }
    }
}