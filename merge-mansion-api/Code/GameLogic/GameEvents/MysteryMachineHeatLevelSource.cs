using Code.GameLogic.Config;
using Metaplay.Core.Config;
using Metaplay.Core.Math;
using System.Collections.Generic;
using Metaplay.Core;
using System;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineHeatLevelSource : IConfigItemSource<MysteryMachineHeatLevelInfo, MysteryMachineHeatLevelId>, IGameConfigSourceItem<MysteryMachineHeatLevelId, MysteryMachineHeatLevelInfo>, IHasGameConfigKey<MysteryMachineHeatLevelId>
    {
        public MysteryMachineHeatLevelId ConfigKey { get; set; }
        private F32 CoughChance { get; set; }
        private List<MetaRef<MysteryMachinePerkInfo>> Perks { get; set; }
        private int SpawnCost { get; set; }

        public MysteryMachineHeatLevelSource()
        {
        }
    }
}