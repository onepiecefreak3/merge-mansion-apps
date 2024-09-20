using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using System;
using Metaplay.Core.Offers;
using Metaplay.Core.Player;

namespace Analytics
{
    [MetaSerializableDerived(1)]
    public class MergeMansionPurchaseAnalyticsContext : PurchaseAnalyticsContext
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string PlacementId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaOfferGroupId GroupId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string ImpressionId { get; set; }

        public MergeMansionPurchaseAnalyticsContext()
        {
        }

        public MergeMansionPurchaseAnalyticsContext(string placementId, string impressionId)
        {
        }

        public MergeMansionPurchaseAnalyticsContext(string placementId, MetaOfferGroupId groupId, string impressionId)
        {
        }

        [MetaMember(4, (MetaMemberFlags)0)]
        public PlayerSegmentId Segment { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string TriggerType { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string OfferItems { get; set; }

        public MergeMansionPurchaseAnalyticsContext(string placementId, MetaOfferGroupId groupId, string impressionId, PlayerSegmentId segment, string triggerType, string offerItems)
        {
        }
    }
}