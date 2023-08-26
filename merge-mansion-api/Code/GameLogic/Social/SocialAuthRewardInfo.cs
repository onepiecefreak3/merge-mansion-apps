using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Code.GameLogic.Config;
using Metaplay.Core;
using System.Collections.Generic;
using GameLogic.Player.Rewards;
using System;

namespace Code.GameLogic.Social
{
    [MetaSerializable]
    public class SocialAuthRewardInfo : IGameConfigData<SocialAuthRewardId>, IGameConfigData, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public SocialAuthRewardId SocialAuthRewardId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public AuthenticationPlatform AuthenticationPlatform { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string InboxTitleShortLocId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string InboxTitleLongLocId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string InboxDescShortLocId { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public string InboxDescLongLocId { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public string InboxImageExcerptId { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public string InboxImageFullId { get; set; }

        public SocialAuthRewardId ConfigKey => SocialAuthRewardId;

        public SocialAuthRewardInfo()
        {
        }

        public SocialAuthRewardInfo(SocialAuthRewardId socialAuthRewardId, AuthenticationPlatform authenticationPlatform, List<PlayerReward> rewards, string inboxTitleShortLocId, string inboxTitleLongLocId, string inboxDescShortLocId, string inboxDescLongLocId, string inboxImageExcerptId, string inboxImageFullId)
        {
        }
    }
}