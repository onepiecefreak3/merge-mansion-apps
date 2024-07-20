using System.Collections.Generic;
using GameLogic.Player.Rewards;
using Metaplay.Core.Config;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Merging
{
    [MetaSerializable]
    public class MergeReward : IGameConfigData<MergeRewardId>, IGameConfigData, IHasGameConfigKey<MergeRewardId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MergeRewardId ConfigKey { get; set; }

        [MetaMember(2, 0)]
        public int ExperienceRequired { get; set; }

        [MetaMember(3, 0)]
        public List<PlayerReward> Rewards { get; set; }

        public MergeReward()
        {
        }
    }
}