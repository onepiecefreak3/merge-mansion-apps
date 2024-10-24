using Metaplay.Core.Analytics;
using System;
using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;

namespace Analytics
{
    [AnalyticsEvent(156, "In App Purchase Refused by Client", 1, null, false, true, false)]
    [Obsolete("Replaced with SDK-side PlayerEventInAppPurchaseClientRefused")]
    public class AnalyticsEventInAppPurchaseClientRefused : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        public InAppPurchaseClientRefuseReason Reason { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public InAppProductId ProductId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string GameProductAnalyticsId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [FirebaseAnalyticsIgnore]
        public PurchaseAnalyticsContext PurchaseContext { get; set; }
        public override string EventDescription { get; }

        private AnalyticsEventInAppPurchaseClientRefused()
        {
        }

        public AnalyticsEventInAppPurchaseClientRefused(InAppPurchaseClientRefuseReason reason, InAppProductId productId, string gameProductAnalyticsId, PurchaseAnalyticsContext purchaseContext)
        {
        }
    }
}