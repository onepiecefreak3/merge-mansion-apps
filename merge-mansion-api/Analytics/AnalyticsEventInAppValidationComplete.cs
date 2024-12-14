using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using Metaplay.Core.InAppPurchase;
using System;
using Metaplay.Core.Math;
using GameLogic.Player;

namespace Analytics
{
    [AnalyticsEvent(155, "In App Purchase Validated", 1, null, false, true, false)]
    public class AnalyticsEventInAppValidationComplete : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        public PlayerEventInAppValidationComplete.ValidationResult Result { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public InAppProductId ProductId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public InAppPurchasePlatform Platform { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string TransactionId { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public string OrderId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string PlatformProductId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public F64 ReferencePrice { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public string GameProductAnalyticsId { get; set; }

        [FirebaseAnalyticsIgnore]
        [MetaMember(8, (MetaMemberFlags)0)]
        public PurchaseAnalyticsContext PurchaseContext { get; set; }
        public override string EventDescription { get; }

        private AnalyticsEventInAppValidationComplete()
        {
        }

        public AnalyticsEventInAppValidationComplete(PlayerModel player, PlayerEventInAppValidationComplete.ValidationResult result, InAppProductId productId, InAppPurchasePlatform platform, string transactionId, string orderId, string platformProductId, F64 referencePrice, string gameProductAnalyticsId, PurchaseAnalyticsContext purchaseContext)
        {
        }
    }
}