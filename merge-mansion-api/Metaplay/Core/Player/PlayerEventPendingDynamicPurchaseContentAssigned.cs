using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using System;

namespace Metaplay.Core.Player
{
    [AnalyticsEvent(1001, "In App Purchase Started (with dynamic content)", 1, "Player is about to start an IAP flow in the platform store. The purchase contents are dynamically generated. The event contents describe the purchase the player is attempting to buy.", true, true, false)]
    [AnalyticsEventKeywords(new string[] { "InAppPurchase" })]
    public class PlayerEventPendingDynamicPurchaseContentAssigned : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public InAppProductId ProductId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [FirebaseAnalyticsIgnore]
        public DynamicPurchaseContent Content { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string DeviceId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string GameProductAnalyticsId { get; set; }

        [FirebaseAnalyticsIgnore]
        [MetaMember(5, (MetaMemberFlags)0)]
        public PurchaseAnalyticsContext PurchaseContext { get; set; }
        public override string EventDescription { get; }

        private PlayerEventPendingDynamicPurchaseContentAssigned()
        {
        }

        public PlayerEventPendingDynamicPurchaseContentAssigned(InAppProductId productId, DynamicPurchaseContent content, string deviceId, string gameProductAnalyticsId, PurchaseAnalyticsContext purchaseContext)
        {
        }
    }
}