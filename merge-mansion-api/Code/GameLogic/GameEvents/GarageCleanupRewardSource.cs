using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace Code.GameLogic.GameEvents
{
    public class GarageCleanupRewardSource : IConfigItemSource<GarageCleanupRewardInfo, GarageCleanupRewardId>, IGameConfigSourceItem<GarageCleanupRewardId, GarageCleanupRewardInfo>, IHasGameConfigKey<GarageCleanupRewardId>
    {
        public GarageCleanupRewardId ConfigKey { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        private string VisualItem { get; set; }

        public GarageCleanupRewardSource()
        {
        }
    }
}