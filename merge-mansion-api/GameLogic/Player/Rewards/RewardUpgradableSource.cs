using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace GameLogic.Player.Rewards
{
    public class RewardUpgradableSource : IConfigItemSource<RewardUpgradableInfo, RewardUpgradableId>, IGameConfigSourceItem<RewardUpgradableId, RewardUpgradableInfo>, IHasGameConfigKey<RewardUpgradableId>
    {
        public RewardUpgradableId ConfigKey { get; set; }
        private List<int> RewardRequiredPoints { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        private CurrencySource OverrideCurrencySource { get; set; }

        public RewardUpgradableSource()
        {
        }
    }
}