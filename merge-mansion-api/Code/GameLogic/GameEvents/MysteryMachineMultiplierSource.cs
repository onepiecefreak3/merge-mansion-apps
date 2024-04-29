using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineMultiplierSource : IConfigItemSource<MysteryMachineMultiplierInfo, MysteryMachineMultiplierId>, IGameConfigSourceItem<MysteryMachineMultiplierId, MysteryMachineMultiplierInfo>, IHasGameConfigKey<MysteryMachineMultiplierId>
    {
        public MysteryMachineMultiplierId ConfigKey { get; set; }
        private int Multiplier { get; set; }
        private string Type { get; set; }
        private int Weight { get; set; }
        private string Loc_Id { get; set; }

        public MysteryMachineMultiplierSource()
        {
        }
    }
}