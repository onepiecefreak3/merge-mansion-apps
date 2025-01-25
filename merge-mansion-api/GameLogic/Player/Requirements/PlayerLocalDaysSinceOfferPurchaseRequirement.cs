using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(56)]
    public class PlayerLocalDaysSinceOfferPurchaseRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaOfferGroupId OfferGroupId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private MetaOfferId OfferId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Days { get; set; }

        public PlayerLocalDaysSinceOfferPurchaseRequirement()
        {
        }

        public PlayerLocalDaysSinceOfferPurchaseRequirement(MetaOfferGroupId offerGroupId, MetaOfferId offerId, int days)
        {
        }
    }
}