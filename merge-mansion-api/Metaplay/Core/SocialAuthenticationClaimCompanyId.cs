using Metaplay.Core.Model;
using System;

namespace Metaplay.Core
{
    [MetaSerializableDerived(10)]
    public class SocialAuthenticationClaimCompanyId : SocialAuthenticationClaimBase
    {
        public override AuthenticationPlatform Platform { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        public string AuthToken { get; set; }

        private SocialAuthenticationClaimCompanyId()
        {
        }

        public SocialAuthenticationClaimCompanyId(string authToken)
        {
        }
    }
}