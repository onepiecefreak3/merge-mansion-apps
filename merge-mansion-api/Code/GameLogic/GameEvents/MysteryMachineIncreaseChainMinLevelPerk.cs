using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(2)]
    public class MysteryMachineIncreaseChainMinLevelPerk : IMysteryMachinePerk
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ChainId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int ChainMinLevelIncrease { get; set; }

        private MysteryMachineIncreaseChainMinLevelPerk()
        {
        }

        public MysteryMachineIncreaseChainMinLevelPerk(string chainId, int chainMinLevelIncrease)
        {
        }
    }
}