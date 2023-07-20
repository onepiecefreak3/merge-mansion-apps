using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core
{
    [MetaSerializableDerived(100)]
    [MetaSerializable]
    public class SocialAuthenticationClaimSupercellId : SocialAuthenticationClaimBase
    {
        [MetaMember(2, 0)]
        public string ScidToken { get; set; } // 0x10

        public override AuthenticationPlatform Platform => AuthenticationPlatform.SupercellId;
        
        public SocialAuthenticationClaimSupercellId() { }

        public SocialAuthenticationClaimSupercellId(string scidToken)
        {
            ScidToken = scidToken;
        }
	}
}
