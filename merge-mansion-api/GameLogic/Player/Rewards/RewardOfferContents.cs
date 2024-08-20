using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using Metaplay.Core;
using GameLogic.Config;
using System.Runtime.Serialization;

namespace GameLogic.Player.Rewards
{
    [MetaBlockedMembers(new int[] { 1 })]
    [MetaSerializableDerived(34)]
    public class RewardOfferContents : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaOfferId OfferId { get; set; }

        public RewardOfferContents()
        {
        }

        public RewardOfferContents(MetaOfferId offerId, CurrencySource source)
        {
        }

        [MetaMember(2, (MetaMemberFlags)0)]
        private MetaRef<MergeMansionOfferInfo> Offer { get; set; }
    }
}