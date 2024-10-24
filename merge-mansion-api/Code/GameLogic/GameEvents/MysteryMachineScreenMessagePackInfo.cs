using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineScreenMessagePackInfo : IGameConfigData<MysteryMachineScreenMessagePackId>, IGameConfigData, IHasGameConfigKey<MysteryMachineScreenMessagePackId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineScreenMessagePackId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<MetaRef<MysteryMachineScreenMessageInfo>> MessageRefs { get; set; }

        public MysteryMachineScreenMessagePackInfo()
        {
        }

        public MysteryMachineScreenMessagePackInfo(MysteryMachineScreenMessagePackId configKey, List<MetaRef<MysteryMachineScreenMessageInfo>> messageRefs)
        {
        }
    }
}