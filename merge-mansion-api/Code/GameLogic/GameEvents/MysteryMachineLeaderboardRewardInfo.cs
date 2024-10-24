using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using GameLogic.Player.Rewards;
using Metaplay.Core.Player;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineLeaderboardRewardInfo : IGameConfigData<MysteryMachineLeaderboardRewardId>, IGameConfigData, IHasGameConfigKey<MysteryMachineLeaderboardRewardId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineLeaderboardRewardId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private List<PlayerReward> Rewards { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<PlayerSegmentId> RewardSegments { get; set; }

        public MysteryMachineLeaderboardRewardInfo()
        {
        }

        public MysteryMachineLeaderboardRewardInfo(MysteryMachineLeaderboardRewardId configKey, List<PlayerReward> rewards, List<PlayerSegmentId> rewardSegments)
        {
        }
    }
}