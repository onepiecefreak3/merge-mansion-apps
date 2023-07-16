using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.GameLogic.Player.Items;
using Metaplay.GameLogic.Player.Requirements;
using Metaplay.GameLogic.Story;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Activables;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Offers;

namespace Metaplay.Code.GameLogic.GameEvents
{
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
