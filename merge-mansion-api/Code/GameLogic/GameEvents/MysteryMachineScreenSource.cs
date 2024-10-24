using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineScreenSource : IConfigItemSource<MysteryMachineScreenInfo, MysteryMachineScreenId>, IGameConfigSourceItem<MysteryMachineScreenId, MysteryMachineScreenInfo>, IHasGameConfigKey<MysteryMachineScreenId>
    {
        public MysteryMachineScreenId ConfigKey { get; set; }
        private List<MetaRef<MysteryMachineScreenMessagePackInfo>> MessagePacks { get; set; }

        public MysteryMachineScreenSource()
        {
        }
    }
}