using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core.Math;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineItemSource : IConfigItemSource<MysteryMachineItemInfo, MysteryMachineItemId>, IGameConfigSourceItem<MysteryMachineItemId, MysteryMachineItemInfo>, IHasGameConfigKey<MysteryMachineItemId>
    {
        public MysteryMachineItemId ConfigKey { get; set; }
        private string ItemType { get; set; }
        private string ItemId { get; set; }
        private F64 CameraMultiplier { get; set; }

        public MysteryMachineItemSource()
        {
        }

        private List<int> WeightsBasedClicks { get; set; }
        private List<int> WeightsBasedHeat { get; set; }
    }
}