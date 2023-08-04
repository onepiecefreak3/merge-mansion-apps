using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using System.Collections.Generic;
using Metaplay.Core.Rewards;

namespace Metaplay.Core.Offers
{
    [MetaSerializableDerived(100)]
    public class MetaOfferGroupOfferDynamicPurchaseContent : DynamicPurchaseContent
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaOfferGroupId GroupId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaOfferId OfferId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<MetaPlayerRewardBase> Rewards { get; set; }
        public override List<MetaPlayerRewardBase> PurchaseRewards { get; }

        private MetaOfferGroupOfferDynamicPurchaseContent()
        {
        }

        public MetaOfferGroupOfferDynamicPurchaseContent(MetaOfferGroupId groupId, MetaOfferId offerId, IEnumerable<MetaPlayerRewardBase> rewards)
        {
        }
    }
}