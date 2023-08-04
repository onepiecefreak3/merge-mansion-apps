using Metaplay.Core.Model;
using Metaplay.Core.Message;

namespace Metaplay.Core.Player
{
    [MetaSerializableDerived(1)]
    public class SocialAuthenticateRequest : MetaRequest
    {
        public SocialAuthenticationClaimBase Claim { get; set; }

        private SocialAuthenticateRequest()
        {
        }

        public SocialAuthenticateRequest(SocialAuthenticationClaimBase claim)
        {
        }
    }
}