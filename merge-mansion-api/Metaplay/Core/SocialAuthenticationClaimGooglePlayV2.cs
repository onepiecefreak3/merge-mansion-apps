using Metaplay.Core.Model;
using System;

namespace Metaplay.Core
{
    [MetaSerializableDerived(8)]
    public class SocialAuthenticationClaimGooglePlayV2 : SocialAuthenticationClaimBase
    {
        public override AuthenticationPlatform Platform { get; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string ServerAuthCode { get; set; }

        public SocialAuthenticationClaimGooglePlayV2()
        {
        }

        public SocialAuthenticationClaimGooglePlayV2(string serverAuthCode)
        {
        }
    }
}