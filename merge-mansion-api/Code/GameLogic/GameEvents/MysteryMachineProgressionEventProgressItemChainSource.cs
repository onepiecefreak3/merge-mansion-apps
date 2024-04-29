using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineProgressionEventProgressItemChainSource : IConfigItemSource<MysteryMachineProgressionEventProgressItemChainInfo, MysteryMachineProgressionEventProgressItemChainId>, IGameConfigSourceItem<MysteryMachineProgressionEventProgressItemChainId, MysteryMachineProgressionEventProgressItemChainInfo>, IHasGameConfigKey<MysteryMachineProgressionEventProgressItemChainId>
    {
        public MysteryMachineProgressionEventProgressItemChainId ConfigKey { get; set; }
        private List<MetaRef<MysteryMachineProgressionEventProgressItemInfo>> Items { get; set; }

        public MysteryMachineProgressionEventProgressItemChainSource()
        {
        }
    }
}