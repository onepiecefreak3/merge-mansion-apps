using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineItemSetSource : IConfigItemSource<MysteryMachineItemSetInfo, MysteryMachineItemSetId>, IGameConfigSourceItem<MysteryMachineItemSetId, MysteryMachineItemSetInfo>, IHasGameConfigKey<MysteryMachineItemSetId>
    {
        public MysteryMachineItemSetId ConfigKey { get; set; }
        private List<MetaRef<MysteryMachineItemInfo>> Items { get; set; }

        public MysteryMachineItemSetSource()
        {
        }
    }
}