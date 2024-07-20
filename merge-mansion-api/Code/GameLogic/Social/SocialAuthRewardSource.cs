using Code.GameLogic.Config;
using Metaplay.Core.Config;
using Metaplay.Core;
using System.Collections.Generic;
using System;

namespace Code.GameLogic.Social
{
    public class SocialAuthRewardSource : IConfigItemSource<SocialAuthRewardInfo, SocialAuthRewardId>, IGameConfigSourceItem<SocialAuthRewardId, SocialAuthRewardInfo>, IHasGameConfigKey<SocialAuthRewardId>
    {
        private SocialAuthRewardId SocialAuthRewardId { get; set; }
        private AuthenticationPlatform AuthenticationPlatform { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        private string InboxTitleShortLocId { get; set; }
        private string InboxTitleLongLocId { get; set; }
        private string InboxDescShortLocId { get; set; }
        private string InboxDescLongLocId { get; set; }
        private string InboxImageExcerptId { get; set; }
        private string InboxImageFullId { get; set; }
        public SocialAuthRewardId ConfigKey { get; }

        public SocialAuthRewardSource()
        {
        }
    }
}