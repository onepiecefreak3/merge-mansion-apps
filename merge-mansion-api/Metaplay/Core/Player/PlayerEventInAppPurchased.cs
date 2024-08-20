using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using System;
using Metaplay.Core.Math;

namespace Metaplay.Core.Player
{
    [AnalyticsEventKeywords(new string[] { "InAppPurchase" })]
    [AnalyticsEvent(1008, null, 2, "In App Purchase has been completed and the rewards have been granted to the player.", true, true, false)]
    public class PlayerEventInAppPurchased : PlayerEventBase
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public InAppProductId ProductId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public InAppPurchasePlatform Platform { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string TransactionId { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public string OrderId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string PlatformProductId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public F64 ReferencePrice { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public string GameProductAnalyticsId { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public InAppPurchasePaymentType? PaymentType { get; set; }

        [FirebaseAnalyticsIgnore]
        [MetaMember(8, (MetaMemberFlags)0)]
        public PurchaseAnalyticsContext PurchaseContext { get; set; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [FirebaseAnalyticsIgnore]
        public ResolvedPurchaseContentBase ResolvedContent { get; set; }

        [FirebaseAnalyticsIgnore]
        [MetaMember(9, (MetaMemberFlags)0)]
        public ResolvedPurchaseContentBase ResolvedDynamicContent { get; set; }

        [FirebaseAnalyticsIgnore]
        [MetaMember(10, (MetaMemberFlags)0)]
        public SubscriptionInstanceState? Subscription { get; set; }
        public override string EventDescription { get; }

        private PlayerEventInAppPurchased()
        {
        }

        public PlayerEventInAppPurchased(InAppProductId productId, InAppPurchasePlatform platform, string transactionId, string orderId, string platformProductId, F64 referencePrice, string gameProductAnalyticsId, InAppPurchasePaymentType? paymentType, PurchaseAnalyticsContext purchaseContext, ResolvedPurchaseContentBase resolvedContent, ResolvedPurchaseContentBase resolvedDynamicContent, SubscriptionInstanceState? subscription)
        {
        }
    }
}