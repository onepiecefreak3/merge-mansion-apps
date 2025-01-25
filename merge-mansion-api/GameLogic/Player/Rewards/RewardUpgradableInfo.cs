using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Code.GameLogic.Config;
using System.Collections.Generic;

namespace GameLogic.Player.Rewards
{
    [MetaSerializable]
    public class RewardUpgradableInfo : IGameConfigData<RewardUpgradableId>, IGameConfigData, IHasGameConfigKey<RewardUpgradableId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public RewardUpgradableId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<RewardUpgradableRewardData> Rewards { get; set; }

        public RewardUpgradableInfo()
        {
        }

        public RewardUpgradableInfo(RewardUpgradableId configKey, List<RewardUpgradableRewardData> rewards)
        {
        }
    }
}