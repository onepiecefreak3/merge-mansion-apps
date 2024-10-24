using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace GameLogic.Fallbacks
{
    public class FallbackPlayerRewardInfoSource : IConfigItemSource<FallbackPlayerRewardInfo, FallbackPlayerRewardId>, IGameConfigSourceItem<FallbackPlayerRewardId, FallbackPlayerRewardInfo>, IHasGameConfigKey<FallbackPlayerRewardId>
    {
        public FallbackPlayerRewardId ConfigKey { get; set; }
        private string RewardType { get; set; }
        private string RewardId { get; set; }
        private string RewardAux0 { get; set; }
        private string RewardAux1 { get; set; }
        private int RewardAmount { get; set; }

        public FallbackPlayerRewardInfoSource()
        {
        }
    }
}