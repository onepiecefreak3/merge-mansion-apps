using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace Code.GameLogic.GameEvents
{
    public class ProgressionEventStreakRewardsSource : IConfigItemSource<ProgressionEventStreakRewards, ProgressionEventStreakId>, IGameConfigSourceItem<ProgressionEventStreakId, ProgressionEventStreakRewards>, IHasGameConfigKey<ProgressionEventStreakId>
    {
        public ProgressionEventStreakId ConfigKey { get; set; }
        private int PurchaseCount { get; set; }
        private string[] RewardType { get; set; }
        private string[] RewardId { get; set; }
        private int[] RewardAmount { get; set; }
        private string[] RewardAux0 { get; set; }
        private string[] RewardAux1 { get; set; }
        public ProgressionEventStreakId SourceConfigKey { get; }

        public ProgressionEventStreakRewardsSource()
        {
        }
    }
}