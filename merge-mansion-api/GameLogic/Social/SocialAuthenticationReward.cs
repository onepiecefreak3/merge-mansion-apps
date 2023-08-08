using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Metaplay.Core;
using System;

namespace GameLogic.Social
{
    [MetaSerializable]
    public class SocialAuthenticationReward : IGameConfigData<AuthenticationPlatform>, IGameConfigData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public AuthenticationPlatform ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string ItemReward { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public Currencies CurrencyReward { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public long CurrencyAmount { get; set; }

        public SocialAuthenticationReward()
        {
        }
    }
}