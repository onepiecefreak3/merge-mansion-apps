using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.MergeChains;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineChainMultiplierInfo : IGameConfigData<MysteryMachineChainMultiplierId>, IGameConfigData, IHasGameConfigKey<MysteryMachineChainMultiplierId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineChainMultiplierId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MergeChainId ChainId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<MysteryMachineMultiplier> MultipliersList { get; set; }

        public MysteryMachineChainMultiplierInfo()
        {
        }

        public MysteryMachineChainMultiplierInfo(MysteryMachineChainMultiplierId configKey, MergeChainId chainId, List<MysteryMachineMultiplier> multipliersList)
        {
        }
    }
}