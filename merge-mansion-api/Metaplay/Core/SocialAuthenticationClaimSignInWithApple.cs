using Metaplay.Core.Model;
using System;

namespace Metaplay.Core
{
    [MetaSerializableDerived(5)]
    public class SocialAuthenticationClaimSignInWithApple : SocialAuthenticationClaimBase
    {
        public override AuthenticationPlatform Platform { get; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string IdentityToken { get; set; }

        public SocialAuthenticationClaimSignInWithApple()
        {
        }

        public SocialAuthenticationClaimSignInWithApple(string identityToken)
        {
        }
    }
}