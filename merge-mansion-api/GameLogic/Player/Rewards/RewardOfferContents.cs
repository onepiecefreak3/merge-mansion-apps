using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using Metaplay.Core;
using GameLogic.Config;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Metaplay.Core.Rewards;

namespace GameLogic.Player.Rewards
{
    [MetaBlockedMembers(new int[] { 1 })]
    [MetaSerializableDerived(34)]
    public class RewardOfferContents : PlayerReward
    {
        [IgnoreDataMember]
        public MetaOfferId OfferId { get; set; }

        public RewardOfferContents()
        {
        }

        public RewardOfferContents(MetaOfferId offerId, CurrencySource source)
        {
        }

        [MetaOnMemberDeserializationFailure("HandleRemovedOffers")]
        [MetaMember(2, (MetaMemberFlags)0)]
        private MetaRef<MergeMansionOfferInfo> Offer { get; set; }

        [IgnoreDataMember]
        public List<MetaPlayerRewardBase> Rewards { get; }
    }
}