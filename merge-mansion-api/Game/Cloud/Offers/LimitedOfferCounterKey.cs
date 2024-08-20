using Metaplay.Core.Model;
using Metaplay.Core.Offers;

namespace Game.Cloud.Offers
{
    [MetaSerializable]
    public class LimitedOfferCounterKey
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaOfferId OfferId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaOfferGroupId OfferGroupId { get; set; }

        public LimitedOfferCounterKey(MetaOfferId offerId, MetaOfferGroupId offerGroupId)
        {
        }

        public LimitedOfferCounterKey()
        {
        }
    }
}