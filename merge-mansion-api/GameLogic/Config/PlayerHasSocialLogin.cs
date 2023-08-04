using Metaplay.Core.Model;
using System;
using Metaplay.Core;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1024)]
    public class PlayerHasSocialLogin : PlayerPropertyMatcher<LoginDateTime>
    {
        public override string DisplayName { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        private AuthenticationPlatform Platform { get; set; }

        private PlayerHasSocialLogin()
        {
        }

        public PlayerHasSocialLogin(AuthenticationPlatform platform)
        {
        }
    }
}