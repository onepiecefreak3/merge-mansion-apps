using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializable]
    public struct RewardUpgradableRewardData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int RequiredPoints { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public PlayerReward Reward { get; set; }
    }
}