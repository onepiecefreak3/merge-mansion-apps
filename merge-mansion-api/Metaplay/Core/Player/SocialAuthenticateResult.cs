using Metaplay.Core.Message;
using Metaplay.Core.Serialization;
using System;

namespace Metaplay.Core.Player
{
    public class SocialAuthenticateResult : MetaResponse
    {
        public enum ResultCode
        {
            Success = 0,
            AuthError = 1,
            TemporarilyUnavailable = 2
        }

        public AuthenticationPlatform Platform { get; set; }
        public SocialAuthenticateResult.ResultCode Result { get; set; }
        public MetaSerialized<IPlayerModelBase> ConflictingPlayer { get; set; }
        public int ConflictResolutionId { get; set; }
        public string DebugOnlyErrorMessage { get; set; }

        private SocialAuthenticateResult()
        {
        }

        public SocialAuthenticateResult(AuthenticationPlatform platform, SocialAuthenticateResult.ResultCode result, MetaSerialized<IPlayerModelBase> conflictingPlayer, int conflictResolutionId, string debugOnlyErrorMessage)
        {
        }
    }
}