using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace Code.GameLogic.GameEvents
{
    public class ProgressionEventPerkSource : IConfigItemSource<ProgressionEventPerkInfo, ProgressionEventPerkId>, IGameConfigSourceItem<ProgressionEventPerkId, ProgressionEventPerkInfo>, IHasGameConfigKey<ProgressionEventPerkId>
    {
        public ProgressionEventPerkId ConfigKey { get; set; }
        private ProgressionEventPerkType PerkType { get; set; }
        private string PerkAux0 { get; set; }
        private string PerkAux1 { get; set; }

        public ProgressionEventPerkSource()
        {
        }
    }
}