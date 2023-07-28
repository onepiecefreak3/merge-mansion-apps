using System.Collections.Generic;
using GameLogic.Player.Items;
using GameLogic.Player.Requirements;
using GameLogic.Story;
using Metaplay.Core;
using Metaplay.Core.Activables;
using Metaplay.Core.Config;
using Metaplay.Core.Model;
using Metaplay.Core.Offers;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class LeaderboardEventInfo : IGameConfigData<LeaderboardEventId>
    {
        [MetaMember(1, 0)]
        public LeaderboardEventId LeaderboardEventId { get; set; }
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
        public PlayerRequirement UnlockRequirement { get; set; }
        [MetaMember(9, 0)]
        public OfferPlacementId BoardShopPlacementId { get; set; }
        [MetaMember(10, 0)]
        public int SecondaryEnergyAttachmentChance { get; set; }
        [MetaMember(11, 0)]
        public List<MetaRef<EventLevelInfo>> RankingRewardLevelRefs { get; set; }
        [MetaMember(12, 0)]
        public List<MetaRef<EventLevelInfo>> LevelRefs { get; set; }
        [MetaMember(13, 0)]
        public StoryDefinitionId EnterBoardDialogue { get; set; }

        public LeaderboardEventId ConfigKey => LeaderboardEventId;
    }
}
