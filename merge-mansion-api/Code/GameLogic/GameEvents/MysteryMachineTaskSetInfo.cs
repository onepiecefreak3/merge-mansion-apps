using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Code.GameLogic.Config;
using System.Collections.Generic;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineTaskSetInfo : IGameConfigData<MysteryMachineTaskSetId>, IGameConfigData, IHasGameConfigKey<MysteryMachineTaskSetId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineTaskSetId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<MetaRef<MysteryMachineTaskInfo>> TaskRefs { get; set; }

        public MysteryMachineTaskSetInfo()
        {
        }

        public MysteryMachineTaskSetInfo(MysteryMachineTaskSetId configKey, List<MetaRef<MysteryMachineTaskInfo>> taskRefs)
        {
        }
    }
}