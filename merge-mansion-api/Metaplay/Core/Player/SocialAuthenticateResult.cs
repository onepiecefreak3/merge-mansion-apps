using Metaplay.Core.Message;
using Metaplay.Core.Serialization;
using System;
using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [MetaSerializableDerived(2)]
    public class SocialAuthenticateResult : MetaResponse
    {
        [MetaSerializable]
        public enum ResultCode
        {
            Success = 0,
            AuthError = 1,
            TemporarilyUnavailable = 2
        }

        public AuthenticationPlatform Platform { get; set; }
        public SocialAuthenticateResult.ResultCode Result { get; set; }
        public int ConflictResolutionId { get; set; }
        public string DebugOnlyErrorMessage { get; set; }

        private SocialAuthenticateResult()
        {
        }

        public SocialAuthenticateResult(AuthenticationPlatform platform, SocialAuthenticateResult.ResultCode result, MetaSerialized<IPlayerModelBase> conflictingPlayer, int conflictResolutionId, string debugOnlyErrorMessage)
        {
        }

        public EntityId ConflictingPlayerId { get; set; }
        public MetaSerialized<IPlayerModelBase> ConflictingPlayerIfAvailable { get; set; }

        public SocialAuthenticateResult(AuthenticationPlatform platform, SocialAuthenticateResult.ResultCode result, EntityId conflictingPlayerId, MetaSerialized<IPlayerModelBase> conflictingPlayer, int conflictResolutionId, string debugOnlyErrorMessage)
        {
        }
    }
}