namespace Metaplay.Core.Network
{
    public readonly struct LoginCredentials
    {
        public readonly string DeviceId; // 0x0
        public readonly string AuthToken; // 0x8
        public readonly EntityId PlayerId; // 0x10
        public readonly bool IsBot; // 0x18
        public readonly SocialAuthenticationClaimBase SocialAuthClaim; // 0x20

        public LoginCredentials(string deviceId, string authToken, EntityId playerId, bool isBot, SocialAuthenticationClaimBase socialAuthClaim)
        {
            DeviceId = deviceId;
            AuthToken = authToken;
            PlayerId = playerId;
            IsBot = isBot;
            SocialAuthClaim = socialAuthClaim;
        }
    }
}
