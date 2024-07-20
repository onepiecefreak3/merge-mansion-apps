using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using System;
using Metaplay.Core.Math;

namespace Metaplay.Core.Player
{
    [AnalyticsEventKeywords(new string[] { "InAppPurchase" })]
    [AnalyticsEvent(1012, null, 1, "Server-side IAP validation was completed. The event contents describe the result of the validation.", true, true, false)]
    public class PlayerEventInAppValidationComplete : PlayerEventBase
    {
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

        [MetaMember(10, (MetaMemberFlags)0)]
        public InAppPurchasePaymentType? PaymentType { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [FirebaseAnalyticsIgnore]
        public PurchaseAnalyticsContext PurchaseContext { get; set; }
        public override string EventDescription { get; }

        private PlayerEventInAppValidationComplete()
        {
        }

        public PlayerEventInAppValidationComplete(PlayerEventInAppValidationComplete.ValidationResult result, InAppProductId productId, InAppPurchasePlatform platform, string transactionId, string orderId, string platformProductId, F64 referencePrice, string gameProductAnalyticsId, InAppPurchasePaymentType? paymentType, PurchaseAnalyticsContext purchaseContext)
        {
        }

        [MetaSerializable]
        public enum ValidationResult
        {
            Valid = 0,
            Invalid = 1,
            Duplicate = 2,
            MissingContent = 3
        }
    }
}