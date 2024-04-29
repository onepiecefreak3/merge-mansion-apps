using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Metaplay.Core.Math;
using System.Collections.Generic;
using Metaplay.Core;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineHeatLevelInfo : IGameConfigData<MysteryMachineHeatLevelId>, IGameConfigData, IHasGameConfigKey<MysteryMachineHeatLevelId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineHeatLevelId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public F32 CoughChance { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<MetaRef<MysteryMachinePerkInfo>> PerkRefs { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int SpawnCost { get; set; }

        public MysteryMachineHeatLevelInfo()
        {
        }

        public MysteryMachineHeatLevelInfo(MysteryMachineHeatLevelId configKey, F32 coughChance, List<MetaRef<MysteryMachinePerkInfo>> perkRefs, int spawnCost)
        {
        }
    }
}