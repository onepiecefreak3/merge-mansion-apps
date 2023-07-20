using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Config;
using Metaplay.GameLogic.ConfigPrefabs;
using Metaplay.GameLogic.Story;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Activables;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class ProgressionEventInfo: IGameConfigData<ProgressionEventId>
    {
        [MetaMember(1)]
        public ProgressionEventId ProgressionEventId { get; set; }
        [MetaMember(2)]
        public string NameLocId { get; set; }
        [MetaMember(3)]
        public string DisplayName { get; set; }
        [MetaMember(4)]
        public string Description { get; set; }
        [MetaMember(5)]
        public List<EventLevelId> FreeEventLevels { get; set; }
        [MetaMember(6)]
        public List<EventLevelId> PremiumEventLevels { get; set; }
        [MetaMember(7)]
        public EventLevelId RecurringFreeEventLevel { get; set; }
        [MetaMember(8)]
        public EventLevelId RecurringPremiumEventLevel { get; set; }
        [MetaMember(9)]
        public List<int> ChancesToSpawnEventItemPerLevel { get; set; }
        [MetaMember(10)]
        public ItemTypeConstant EventItem { get; set; }
        [MetaMember(11)]
        public MetaRef<InAppProductInfo> PremiumIAP { get; set; }
        [MetaMember(12, 0)]
        public MetaActivableParams ActivableParams { get; set; }
        [MetaMember(13, 0)]
        public int PremiumIAPOfferMinLevel { get; set; }
        [MetaMember(14, 0)]
        public ConfigPrefabId HudButtonId { get; set; }
        [MetaMember(15, 0)]
        public ConfigPrefabId StartPopupId { get; set; }
        [MetaMember(16, 0)]
        public ConfigPrefabId InfoPopupId { get; set; }
        [MetaMember(17, 0)]
        public ConfigPrefabId ProgressionPopupId { get; set; }
        [MetaMember(18, 0)]
        public ConfigPrefabId EndPopupId { get; set; }
        [MetaMember(19, 0)]
        public StoryDefinitionId IntroDialogue { get; set; }

        public ProgressionEventId ConfigKey => ProgressionEventId;
    }
}
