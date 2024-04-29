using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineMultiplierInfo : IGameConfigData<MysteryMachineMultiplierId>, IGameConfigData, IHasGameConfigKey<MysteryMachineMultiplierId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineMultiplierId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Multiplier { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Type { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int Weight { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string LocId { get; set; }

        public MysteryMachineMultiplierInfo()
        {
        }

        public MysteryMachineMultiplierInfo(MysteryMachineMultiplierId configKey, int multiplier, string type, int weight, string locId)
        {
        }
    }
}