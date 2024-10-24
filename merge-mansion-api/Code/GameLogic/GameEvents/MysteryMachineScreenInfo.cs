using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineScreenInfo : IGameConfigData<MysteryMachineScreenId>, IGameConfigData, IHasGameConfigKey<MysteryMachineScreenId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineScreenId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<MetaRef<MysteryMachineScreenMessagePackInfo>> MessagePackRefs { get; set; }

        public MysteryMachineScreenInfo()
        {
        }

        public MysteryMachineScreenInfo(MysteryMachineScreenId configKey, List<MetaRef<MysteryMachineScreenMessagePackInfo>> messagePackRefs)
        {
        }
    }
}