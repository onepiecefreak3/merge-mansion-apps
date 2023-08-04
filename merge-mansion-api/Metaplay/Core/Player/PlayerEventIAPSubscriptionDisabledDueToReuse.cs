using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using System;

namespace Metaplay.Core.Player
{
    [AnalyticsEvent(1016, "IAP Subscription Disabled Due To Reuse", 1, "An IAP subscription was disabled for this player because the same purchase was reused on another player account. This can happen due to subscription restoration. The subscription can be enabled again by restoring it again on this player account.", true, true, false)]
    public class PlayerEventIAPSubscriptionDisabledDueToReuse : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public InAppProductId ProductId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string OriginalTransactionId { get; set; }
        public override string EventDescription { get; }

        private PlayerEventIAPSubscriptionDisabledDueToReuse()
        {
        }

        public PlayerEventIAPSubscriptionDisabledDueToReuse(InAppProductId productId, string originalTransactionId)
        {
        }
    }
}