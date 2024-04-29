using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(2)]
    public class MysteryMachineCurrencyItem : IMysteryMachineItem
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineCurrencyItemChainId ChainId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int ChainItemIndex { get; set; }

        private MysteryMachineCurrencyItem()
        {
        }

        public MysteryMachineCurrencyItem(MysteryMachineCurrencyItemChainId chainId, int chainItemIndex)
        {
        }
    }
}