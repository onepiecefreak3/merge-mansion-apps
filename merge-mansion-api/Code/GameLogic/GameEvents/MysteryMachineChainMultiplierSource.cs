using Code.GameLogic.Config;
using Metaplay.Core.Config;
using GameLogic.MergeChains;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineChainMultiplierSource : IConfigItemSource<MysteryMachineChainMultiplierInfo, MysteryMachineChainMultiplierId>, IGameConfigSourceItem<MysteryMachineChainMultiplierId, MysteryMachineChainMultiplierInfo>, IHasGameConfigKey<MysteryMachineChainMultiplierId>
    {
        public MysteryMachineChainMultiplierId ConfigKey { get; set; }
        private MergeChainId MergeChainId { get; set; }
        private List<MysteryMachineMultiplier> MysteryMachineMultipliers { get; set; }

        public MysteryMachineChainMultiplierSource()
        {
        }
    }
}