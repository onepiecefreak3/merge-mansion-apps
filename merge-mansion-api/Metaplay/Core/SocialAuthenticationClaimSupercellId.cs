using Metaplay.Core.Model;
using System;

namespace Metaplay.Core
{
    [MetaSerializableDerived(100)]
    public class SocialAuthenticationClaimSupercellId : SocialAuthenticationClaimBase
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public string ScidToken { get; set; } // 0x10
        public override AuthenticationPlatform Platform => AuthenticationPlatform.SupercellId;

        public SocialAuthenticationClaimSupercellId()
        {
        }

        public SocialAuthenticationClaimSupercellId(string scidToken)
        {
            ScidToken = scidToken;
        }
    }
}