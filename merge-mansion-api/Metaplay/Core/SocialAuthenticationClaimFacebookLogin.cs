using Metaplay.Core.Model;
using System;

namespace Metaplay.Core
{
    [MetaSerializableDerived(6)]
    public class SocialAuthenticationClaimFacebookLogin : SocialAuthenticationClaimBase
    {
        public override AuthenticationPlatform Platform { get; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string AccessTokenOrOIDCToken { get; set; }

        public SocialAuthenticationClaimFacebookLogin()
        {
        }

        public SocialAuthenticationClaimFacebookLogin(string accessTokenOrOIDCToken)
        {
        }
    }
}