using Metaplay.Core.Model;
using System;

namespace Metaplay.Core
{
    [MetaSerializableDerived(4)]
    public class SocialAuthenticationClaimGoogleSignIn : SocialAuthenticationClaimBase
    {
        public override AuthenticationPlatform Platform { get; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string IdToken { get; set; }

        public SocialAuthenticationClaimGoogleSignIn()
        {
        }

        public SocialAuthenticationClaimGoogleSignIn(string idToken)
        {
        }
    }
}