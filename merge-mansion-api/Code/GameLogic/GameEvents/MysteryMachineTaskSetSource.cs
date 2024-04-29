using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineTaskSetSource : IConfigItemSource<MysteryMachineTaskSetInfo, MysteryMachineTaskSetId>, IGameConfigSourceItem<MysteryMachineTaskSetId, MysteryMachineTaskSetInfo>, IHasGameConfigKey<MysteryMachineTaskSetId>
    {
        public MysteryMachineTaskSetId ConfigKey { get; set; }
        private List<MetaRef<MysteryMachineTaskInfo>> Tasks { get; set; }

        public MysteryMachineTaskSetSource()
        {
        }
    }
}