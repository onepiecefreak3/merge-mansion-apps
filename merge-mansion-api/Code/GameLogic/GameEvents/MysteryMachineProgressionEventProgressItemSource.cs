using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineProgressionEventProgressItemSource : IConfigItemSource<MysteryMachineProgressionEventProgressItemInfo, MysteryMachineProgressionEventProgressItemId>, IGameConfigSourceItem<MysteryMachineProgressionEventProgressItemId, MysteryMachineProgressionEventProgressItemInfo>, IHasGameConfigKey<MysteryMachineProgressionEventProgressItemId>
    {
        public MysteryMachineProgressionEventProgressItemId ConfigKey { get; set; }
        private int Amount { get; set; }

        public MysteryMachineProgressionEventProgressItemSource()
        {
        }
    }
}