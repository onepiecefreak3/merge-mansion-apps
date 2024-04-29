using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineSpecialItemSource : IConfigItemSource<MysteryMachineSpecialItemInfo, MysteryMachineSpecialItemItemId>, IGameConfigSourceItem<MysteryMachineSpecialItemItemId, MysteryMachineSpecialItemInfo>, IHasGameConfigKey<MysteryMachineSpecialItemItemId>
    {
        public MysteryMachineSpecialItemItemId ConfigKey { get; set; }
        private string ItemId { get; set; }
        private List<MysteryMachineSpecialityType> Speciality { get; set; }

        public MysteryMachineSpecialItemSource()
        {
        }
    }
}