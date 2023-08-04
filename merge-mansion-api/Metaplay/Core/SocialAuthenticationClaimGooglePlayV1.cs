using Metaplay.Core.Model;
using System;

namespace Metaplay.Core
{
    [MetaSerializableDerived(2)]
    public class SocialAuthenticationClaimGooglePlayV1 : SocialAuthenticationClaimBase
    {
        public override AuthenticationPlatform Platform { get; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string IdToken { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string ServerAuthCode { get; set; }

        private SocialAuthenticationClaimGooglePlayV1()
        {
        }

        public SocialAuthenticationClaimGooglePlayV1(string idToken, string optionalServerAuthCode)
        {
        }
    }
}