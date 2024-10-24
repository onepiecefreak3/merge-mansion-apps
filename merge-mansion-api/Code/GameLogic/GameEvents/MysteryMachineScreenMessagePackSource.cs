using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineScreenMessagePackSource : IConfigItemSource<MysteryMachineScreenMessagePackInfo, MysteryMachineScreenMessagePackId>, IGameConfigSourceItem<MysteryMachineScreenMessagePackId, MysteryMachineScreenMessagePackInfo>, IHasGameConfigKey<MysteryMachineScreenMessagePackId>
    {
        public MysteryMachineScreenMessagePackId ConfigKey { get; set; }
        private List<MetaRef<MysteryMachineScreenMessageInfo>> Messages { get; set; }

        public MysteryMachineScreenMessagePackSource()
        {
        }
    }
}