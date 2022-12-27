using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Player.Rewards;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Merging
{
    public class MergeReward : IGameConfigData<MergeRewardId>
    {
        [MetaMember(1, 0)]
        public MergeRewardId ConfigKey { get; set; }
        [MetaMember(2, 0)]
        public int ExperienceRequired { get; set; }
        [MetaMember(3, 0)]
        public List<PlayerReward> Rewards { get; set; }
	}
}
