using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    public class BoultonLeagueStageSource : IConfigItemSource<BoultonLeagueStageInfo, BoultonLeagueStageId>, IGameConfigSourceItem<BoultonLeagueStageId, BoultonLeagueStageInfo>, IHasGameConfigKey<BoultonLeagueStageId>
    {
        public BoultonLeagueStageId ConfigKey { get; set; }
        public int? DemotionScoreThreshold { get; set; }
        public int FinishRewardAmount { get; set; }
        public string FinishRewardAux0 { get; set; }
        public string FinishRewardAux1 { get; set; }
        public string FinishRewardId { get; set; }
        public string FinishRewardType { get; set; }
        public List<MetaRef<EventLevelInfo>> LeaderboardPlacementRewardLevels { get; set; }
        public string NameLocId { get; set; }
        public int PromotionRewardAmount { get; set; }
        public string PromotionRewardAux0 { get; set; }
        public string PromotionRewardAux1 { get; set; }
        public string PromotionRewardId { get; set; }
        public string PromotionRewardType { get; set; }
        public int? PromotionScoreThreshold { get; set; }

        public BoultonLeagueStageSource()
        {
        }
    }
}