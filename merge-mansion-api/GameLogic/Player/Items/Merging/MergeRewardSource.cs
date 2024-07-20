using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace GameLogic.Player.Items.Merging
{
    public class MergeRewardSource : IConfigItemSource<MergeReward, MergeRewardId>, IGameConfigSourceItem<MergeRewardId, MergeReward>, IHasGameConfigKey<MergeRewardId>
    {
        public MergeRewardId ConfigKey { get; set; }
        public int ExperienceRequired { get; set; }
        public List<string> RewardType { get; set; }
        public List<string> RewardId { get; set; }
        public List<int> RewardAmount { get; set; }
        public List<string> RewardAux0 { get; set; }
        public List<string> RewardAux1 { get; set; }

        public MergeRewardSource()
        {
        }
    }
}