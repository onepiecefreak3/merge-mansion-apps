using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineLeaderboardTopRankingRewardInfo : IGameConfigData<MysteryMachineLeaderboardTopRankingRewardId>, IGameConfigData, IHasGameConfigKey<MysteryMachineLeaderboardTopRankingRewardId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineLeaderboardTopRankingRewardId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int FirstRank { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int LastRank { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaRef<MysteryMachineLeaderboardRewardInfo> RewardRef { get; set; }

        public MysteryMachineLeaderboardTopRankingRewardInfo()
        {
        }

        public MysteryMachineLeaderboardTopRankingRewardInfo(MysteryMachineLeaderboardTopRankingRewardId configKey, int firstRank, int lastRank, MetaRef<MysteryMachineLeaderboardRewardInfo> rewardRef)
        {
        }
    }
}