namespace Metaplay.Core
{
    public abstract class SocialAuthenticationClaimBase
    {
        // Properties
        public abstract AuthenticationPlatform Platform { get; }

        public SocialAuthenticationClaimBase()
        {
        }
    }
}