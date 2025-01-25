using Code.GameLogic.Config;
using Metaplay.Core.Config;
using Merge;
using Metaplay.Core;
using GameLogic;
using System.Collections.Generic;
using System;
using Metaplay.Core.Offers;
using GameLogic.Story;

namespace Code.GameLogic.GameEvents
{
    public class ShortLeaderboardEventStageSource : IConfigItemSource<ShortLeaderboardEventStageInfo, ShortLeaderboardEventStageId>, IGameConfigSourceItem<ShortLeaderboardEventStageId, ShortLeaderboardEventStageInfo>, IHasGameConfigKey<ShortLeaderboardEventStageId>
    {
        public ShortLeaderboardEventStageId ConfigKey { get; set; }
        private MergeBoardId BoardId { get; set; }
        private MetaDuration StartTime { get; set; }
        private MetaDuration Duration { get; set; }
        private Currencies ReplayCostCurrency { get; set; }
        private List<long> ReplayCostAmount { get; set; }
        private MetaDuration ReplayCostCooldown { get; set; }
        private OfferPlacementId BoardShopPlacementId { get; set; }
        private int AuxEnergyAttachmentChance { get; set; }
        private int StarsToComplete { get; set; }
        private List<MetaRef<EventLevelInfo>> Levels { get; set; }
        private StoryDefinitionId EnterBoardDialogue { get; set; }
        private StoryDefinitionId CompletionDialogue { get; set; }
        private List<string> CompletionRewardType { get; set; }
        private List<string> CompletionRewardId { get; set; }
        private List<string> CompletionRewardAux0 { get; set; }
        private List<string> CompletionRewardAux1 { get; set; }
        private List<int> CompletionRewardAmount { get; set; }
        private List<int> RankingPositionStars { get; set; }

        public ShortLeaderboardEventStageSource()
        {
        }
    }
}