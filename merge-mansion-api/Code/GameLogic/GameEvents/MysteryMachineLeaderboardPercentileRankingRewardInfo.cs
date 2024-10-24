using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Metaplay.Core.Math;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineLeaderboardPercentileRankingRewardInfo : IGameConfigData<MysteryMachineLeaderboardPercentileRankingRewardId>, IGameConfigData, IHasGameConfigKey<MysteryMachineLeaderboardPercentileRankingRewardId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineLeaderboardPercentileRankingRewardId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public F64 Percentile { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaRef<MysteryMachineLeaderboardRewardInfo> RewardRef { get; set; }

        public MysteryMachineLeaderboardPercentileRankingRewardInfo()
        {
        }

        public MysteryMachineLeaderboardPercentileRankingRewardInfo(MysteryMachineLeaderboardPercentileRankingRewardId configKey, F64 percentile, MetaRef<MysteryMachineLeaderboardRewardInfo> rewardRef)
        {
        }
    }
}