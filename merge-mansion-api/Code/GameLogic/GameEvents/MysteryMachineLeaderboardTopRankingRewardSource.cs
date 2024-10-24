using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineLeaderboardTopRankingRewardSource : IConfigItemSource<MysteryMachineLeaderboardTopRankingRewardInfo, MysteryMachineLeaderboardTopRankingRewardId>, IGameConfigSourceItem<MysteryMachineLeaderboardTopRankingRewardId, MysteryMachineLeaderboardTopRankingRewardInfo>, IHasGameConfigKey<MysteryMachineLeaderboardTopRankingRewardId>
    {
        public MysteryMachineLeaderboardTopRankingRewardId ConfigKey { get; set; }
        private int FirstRank { get; set; }
        private string LastRank { get; set; }
        private MetaRef<MysteryMachineLeaderboardRewardInfo> Reward { get; set; }

        public MysteryMachineLeaderboardTopRankingRewardSource()
        {
        }
    }
}