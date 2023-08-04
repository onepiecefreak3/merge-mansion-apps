using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Player
{
    [AnalyticsEvent(1002, null, 1, "Facebook authentication has been revoked. The event contents describe the reason for revocation (for example: deauthentication on Facebook, or Data Deletion Request on Facebook).", true, true, false)]
    public class PlayerEventFacebookAuthenticationRevoked : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ConfirmationCode { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public PlayerEventFacebookAuthenticationRevoked.RevocationSource Source { get; set; }
        public override string EventDescription { get; }

        private PlayerEventFacebookAuthenticationRevoked()
        {
        }

        public PlayerEventFacebookAuthenticationRevoked(PlayerEventFacebookAuthenticationRevoked.RevocationSource source, string confirmationCode)
        {
        }

        [MetaSerializable]
        public enum RevocationSource
        {
            DataDeletionRequest = 0,
            DeauthorizationRequest = 1
        }
    }
}