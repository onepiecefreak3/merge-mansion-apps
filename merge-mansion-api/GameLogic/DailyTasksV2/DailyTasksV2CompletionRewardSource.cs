using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace GameLogic.DailyTasksV2
{
    public class DailyTasksV2CompletionRewardSource : IConfigItemSource<DailyTasksV2CompletionRewardInfo, DailyTasksV2CompletionRewardId>, IGameConfigSourceItem<DailyTasksV2CompletionRewardId, DailyTasksV2CompletionRewardInfo>, IHasGameConfigKey<DailyTasksV2CompletionRewardId>
    {
        public DailyTasksV2CompletionRewardId ConfigKey { get; set; }
        public int RewardAmount { get; set; }
        public string RewardAux0 { get; set; }
        public string RewardAux1 { get; set; }
        public string RewardId { get; set; }
        public string RewardType { get; set; }

        public DailyTasksV2CompletionRewardSource()
        {
        }
    }
}