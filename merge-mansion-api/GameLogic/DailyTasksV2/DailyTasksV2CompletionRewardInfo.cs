using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.Player.Rewards;

namespace GameLogic.DailyTasksV2
{
    [MetaSerializable]
    public class DailyTasksV2CompletionRewardInfo : IGameConfigData<DailyTasksV2CompletionRewardId>, IGameConfigData, IHasGameConfigKey<DailyTasksV2CompletionRewardId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DailyTasksV2CompletionRewardId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public PlayerReward Reward { get; set; }

        public DailyTasksV2CompletionRewardInfo()
        {
        }

        public DailyTasksV2CompletionRewardInfo(DailyTasksV2CompletionRewardId configKey, PlayerReward reward)
        {
        }
    }
}