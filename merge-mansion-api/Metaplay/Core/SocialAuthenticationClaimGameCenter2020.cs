using Metaplay.Core.Model;
using System;

namespace Metaplay.Core
{
    [MetaSerializableDerived(7)]
    public class SocialAuthenticationClaimGameCenter2020 : SocialAuthenticationClaimBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string TeamPlayerId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public string GamePlayerId;
        [MetaMember(3, (MetaMemberFlags)0)]
        public string PublicKeyUrl;
        [MetaMember(4, (MetaMemberFlags)0)]
        public ulong Timestamp;
        [MetaMember(5, (MetaMemberFlags)0)]
        public string Signature;
        [MetaMember(6, (MetaMemberFlags)0)]
        public string Salt;
        [MetaMember(7, (MetaMemberFlags)0)]
        public string BundleId;
        public override AuthenticationPlatform Platform { get; }

        public SocialAuthenticationClaimGameCenter2020()
        {
        }

        public SocialAuthenticationClaimGameCenter2020(string teamPlayerId, string gamePlayerId, string publicKeyUrl, ulong timestamp, string signature, string salt, string bundleId)
        {
        }
    }
}