using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using System;

namespace Metaplay.Core.Player
{
    [AnalyticsEventKeywords(new string[] { "InAppPurchase" })]
    [AnalyticsEvent(1014, "In App Purchase Refused by Client", 1, "Client-side refusal in the IAP flow in the platform store. This can be either a store failure, or user cancellation. The event contents describe the error code of the refusal.", true, true, false)]
    public class PlayerEventInAppPurchaseClientRefused : PlayerEventBase
    {
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

        private PlayerEventInAppPurchaseClientRefused()
        {
        }

        public PlayerEventInAppPurchaseClientRefused(InAppPurchaseClientRefuseReason reason, InAppProductId productId, string gameProductAnalyticsId, PurchaseAnalyticsContext purchaseContext)
        {
        }
    }
}