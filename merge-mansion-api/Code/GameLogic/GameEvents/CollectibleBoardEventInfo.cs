using Metaplay.Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.GameLogic.Player.Items;
using Metaplay.GameLogic.Player.Requirements;
using Metaplay.GameLogic.Story;
using Metaplay.Metaplay.Core.Activables;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Offers;
using Metaplay.Metaplay.Core;

namespace Metaplay.Code.GameLogic.GameEvents
{
    public class CollectibleBoardEventInfo : IGameConfigData<CollectibleBoardEventId>
    {
        [MetaMember(1, 0)]
        public CollectibleBoardEventId CollectibleBoardEventId { get; set; }
        [MetaMember(2, 0)]
        public string NameLocId { get; set; }
        [MetaMember(3, 0)]
        public string DisplayName { get; set; }
        [MetaMember(4, 0)]
        public string Description { get; set; }
        [MetaMember(5, 0)]
        public MetaActivableParams ActivableParams { get; set; }
        [MetaMember(6, 0)]
        public MetaRef<BoardInfo> BoardRef { get; set; }
        [MetaMember(7, 0)]
        public MetaRef<ItemDefinition> PortalItemRef { get; set; }
        [MetaMember(8, 0)]
        public List<MetaRef<EventLevelInfo>> LevelRefs { get; set; }
        [MetaMember(9, 0)]
        public List<MetaRef<EventLevelInfo>> RecurringLevelRefs { get; set; }
        [MetaMember(10, 0)]
        public Dictionary<MetaRef<EventLevelInfo>, MetaRef<EventLevelInfo>> FallbackLevelRefs { get; set; }
        [MetaMember(11, 0)]
        public StoryDefinitionId EnterBoardDialogue { get; set; }
        [MetaMember(12, 0)]
        public PlayerRequirement UnlockRequirement { get; set; }
        [MetaMember(13, 0)]
        public OfferPlacementId BoardShopPlacementId { get; set; }
        [MetaMember(14, 0)]
        public StoryDefinitionId EndDialogue { get; set; }

        public CollectibleBoardEventId ConfigKey => CollectibleBoardEventId;
    }
}
