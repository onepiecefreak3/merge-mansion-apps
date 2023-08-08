using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Metaplay.Core;
using System;
using Code.GameLogic.Social;

namespace GameLogic.Social
{
    [MetaSerializable]
    public class SocialAuthenticationConfig : IGameConfigData<AuthenticationPlatform>, IGameConfigData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public AuthenticationPlatform AuthenticationPlatformId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool IsEnabled { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public SocialAuthRewardId SocialAuthRewardId { get; set; }
        public AuthenticationPlatform ConfigKey => AuthenticationPlatformId;

        public SocialAuthenticationConfig()
        {
        }
    }
}