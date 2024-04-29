using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineProgressionEventProgressItemChainInfo : IGameConfigData<MysteryMachineProgressionEventProgressItemChainId>, IGameConfigData, IHasGameConfigKey<MysteryMachineProgressionEventProgressItemChainId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineProgressionEventProgressItemChainId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<MetaRef<MysteryMachineProgressionEventProgressItemInfo>> ItemRefs { get; set; }

        public MysteryMachineProgressionEventProgressItemChainInfo()
        {
        }

        public MysteryMachineProgressionEventProgressItemChainInfo(MysteryMachineProgressionEventProgressItemChainId configKey, List<MetaRef<MysteryMachineProgressionEventProgressItemInfo>> itemRefs)
        {
        }
    }
}