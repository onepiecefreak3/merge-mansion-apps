using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace Code.GameLogic.DynamicEvents
{
    public class DynamicEventRewardConfigSourceItem : IConfigItemSource<DynamicEventRewardInfo, DynamicEventRewardId>, IGameConfigSourceItem<DynamicEventRewardId, DynamicEventRewardInfo>, IHasGameConfigKey<DynamicEventRewardId>
    {
        private DynamicEventRewardId EventId { get; set; }
        private int RewardPoints { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        public DynamicEventRewardId ConfigKey { get; }

        public DynamicEventRewardConfigSourceItem()
        {
        }
    }
}