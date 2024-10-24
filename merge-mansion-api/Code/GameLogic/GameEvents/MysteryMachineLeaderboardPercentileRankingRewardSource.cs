using Code.GameLogic.Config;
using Metaplay.Core.Config;
using Metaplay.Core.Math;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineLeaderboardPercentileRankingRewardSource : IConfigItemSource<MysteryMachineLeaderboardPercentileRankingRewardInfo, MysteryMachineLeaderboardPercentileRankingRewardId>, IGameConfigSourceItem<MysteryMachineLeaderboardPercentileRankingRewardId, MysteryMachineLeaderboardPercentileRankingRewardInfo>, IHasGameConfigKey<MysteryMachineLeaderboardPercentileRankingRewardId>
    {
        public MysteryMachineLeaderboardPercentileRankingRewardId ConfigKey { get; set; }
        private F64 Percentile { get; set; }
        private MetaRef<MysteryMachineLeaderboardRewardInfo> Reward { get; set; }

        public MysteryMachineLeaderboardPercentileRankingRewardSource()
        {
        }
    }
}