using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachinePerkSource : IConfigItemSource<MysteryMachinePerkInfo, MysteryMachinePerkId>, IGameConfigSourceItem<MysteryMachinePerkId, MysteryMachinePerkInfo>, IHasGameConfigKey<MysteryMachinePerkId>
    {
        public MysteryMachinePerkId ConfigKey { get; set; }
        private string PerkType { get; set; }
        private List<string> PerkAux { get; set; }

        public MysteryMachinePerkSource()
        {
        }
    }
}