using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Player;

namespace Metaplay.Metaplay.Unity
{
	public interface IMetaplayClientSocialAuthenticationDelegate
    {
        // Methods

        // RVA: -1 Offset: -1 Slot: 0
        void OnSocialAuthenticationSuccess(AuthenticationPlatform platform);

        // RVA: -1 Offset: -1 Slot: 1
        void OnSocialAuthenticationFailure(AuthenticationPlatform platform, SocialAuthenticateResult.ResultCode errorCode, string debugOnlyErrorMessage);

        // RVA: -1 Offset: -1 Slot: 2
        void OnSocialAuthenticationConflict(AuthenticationPlatform platform, int conflictResolutionId, IPlayerModelBase conflictingPlayer);
    }
}
