using Metaplay.Core.Model;
using System;

namespace Metaplay.Core
{
    [MetaSerializableDerived(1)]
    public class SocialAuthenticationClaimDevelopment : SocialAuthenticationClaimBase
    {
        public override AuthenticationPlatform Platform { get; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string AuthToken { get; set; }

        public SocialAuthenticationClaimDevelopment()
        {
        }

        public SocialAuthenticationClaimDevelopment(string authToken)
        {
        }
    }
}