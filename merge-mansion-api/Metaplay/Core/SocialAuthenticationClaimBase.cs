using Metaplay.Core.Model;

namespace Metaplay.Core
{
    [MetaSerializable]
    public abstract class SocialAuthenticationClaimBase
    {
        // Properties
        public abstract AuthenticationPlatform Platform { get; }

        public SocialAuthenticationClaimBase()
        {
        }
    }
}