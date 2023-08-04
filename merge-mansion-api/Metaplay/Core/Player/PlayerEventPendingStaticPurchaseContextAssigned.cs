using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using System;

namespace Metaplay.Core.Player
{
    [AnalyticsEvent(1013, "In App Purchase Started", 1, "Player is about to start an IAP flow in the platform store. The purchase contents are specified in the IAP config. The event contents describe the purchase the player is attempting to buy.", true, true, false)]
    public class PlayerEventPendingStaticPurchaseContextAssigned : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public InAppProductId ProductId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DeviceId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string GameProductAnalyticsId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [FirebaseAnalyticsIgnore]
        public PurchaseAnalyticsContext PurchaseContext { get; set; }
        public override string EventDescription { get; }

        private PlayerEventPendingStaticPurchaseContextAssigned()
        {
        }

        public PlayerEventPendingStaticPurchaseContextAssigned(InAppProductId productId, string deviceId, string gameProductAnalyticsId, PurchaseAnalyticsContext purchaseContext)
        {
        }
    }
}