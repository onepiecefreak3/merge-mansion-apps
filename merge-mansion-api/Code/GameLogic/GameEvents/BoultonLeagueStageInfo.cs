using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Player.Rewards;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class BoultonLeagueStageInfo : IGameConfigData<BoultonLeagueStageId>, IGameConfigData, IHasGameConfigKey<BoultonLeagueStageId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public BoultonLeagueStageId StageId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string NameLocId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<MetaRef<EventLevelInfo>> LeaderboardPlacementRewardLevelRefs { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int? DemotionScoreThreshold { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int? PromotionScoreThreshold { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public PlayerReward FinishReward { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public PlayerReward PromotionReward { get; set; }

        public BoultonLeagueStageId ConfigKey => StageId;

        public BoultonLeagueStageInfo()
        {
        }

        public BoultonLeagueStageInfo(BoultonLeagueStageId stageId, string nameLocId, List<MetaRef<EventLevelInfo>> leaderboardPlacementRewardLevelRefs, int? demotionScoreThreshold, int? promotionScoreThreshold, PlayerReward finishReward, PlayerReward promotionReward)
        {
        }
    }
}