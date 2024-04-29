using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineItemSetInfo : IGameConfigData<MysteryMachineItemSetId>, IGameConfigData, IHasGameConfigKey<MysteryMachineItemSetId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineItemSetId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<MetaRef<MysteryMachineItemInfo>> ItemRefs { get; set; }

        public MysteryMachineItemSetInfo()
        {
        }

        public MysteryMachineItemSetInfo(MysteryMachineItemSetId configKey, List<MetaRef<MysteryMachineItemInfo>> itemRefs)
        {
        }
    }
}