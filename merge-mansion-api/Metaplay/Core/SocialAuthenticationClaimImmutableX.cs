using Metaplay.Core.Model;
using System;

namespace Metaplay.Core
{
    [MetaSerializableDerived(9)]
    public class SocialAuthenticationClaimImmutableX : SocialAuthenticationClaimBase
    {
        public override AuthenticationPlatform Platform { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        public string ClaimedImmutableXAccount { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string ClaimedEthereumAccount { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public EntityId ChallengePlayerId { get; set; }
        public DateTime ChallengeTimestamp { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string ChallengeSignature { get; set; }

        private SocialAuthenticationClaimImmutableX()
        {
        }

        public SocialAuthenticationClaimImmutableX(string claimedImmutableXAccount, string claimedEthereumAccount, EntityId challengePlayerId, MetaTime challengeTimestamp, string challengeSignature)
        {
        }

        [MetaMember(4, (MetaMemberFlags)0)]
        private MetaTime _challengeTimestamp;
        public SocialAuthenticationClaimImmutableX(string claimedImmutableXAccount, string claimedEthereumAccount, EntityId challengePlayerId, DateTime challengeTimestamp, string challengeSignature)
        {
        }
    }
}