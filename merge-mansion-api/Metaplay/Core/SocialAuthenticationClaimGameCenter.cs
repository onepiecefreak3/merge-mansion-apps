using Metaplay.Core.Model;
using System;

namespace Metaplay.Core
{
    [MetaSerializableDerived(3)]
    public class SocialAuthenticationClaimGameCenter : SocialAuthenticationClaimBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string LegacyUserId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public string PublicKeyUrl;
        [MetaMember(3, (MetaMemberFlags)0)]
        public ulong Timestamp;
        [MetaMember(4, (MetaMemberFlags)0)]
        public string Signature;
        [MetaMember(5, (MetaMemberFlags)0)]
        public string Salt;
        [MetaMember(6, (MetaMemberFlags)0)]
        public string BundleId;
        [MetaMember(7, (MetaMemberFlags)0)]
        public SocialAuthenticationClaimGameCenter2020 GameCenter2020MigrationClaim;
        public override AuthenticationPlatform Platform { get; }

        public SocialAuthenticationClaimGameCenter()
        {
        }

        public SocialAuthenticationClaimGameCenter(string legacyUserId, string publicKeyUrl, ulong timestamp, string signature, string salt, string bundleId, SocialAuthenticationClaimGameCenter2020 optionalMigrationClaim)
        {
        }
    }
}