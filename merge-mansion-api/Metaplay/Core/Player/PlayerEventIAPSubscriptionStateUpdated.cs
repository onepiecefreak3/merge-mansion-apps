using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using System;

namespace Metaplay.Core.Player
{
    [AnalyticsEventKeywords(new string[] { "InAppPurchase" })]
    [AnalyticsEvent(1015, "IAP Subscription State Updated", 1, "The state of an IAP subscription was updated. A state update can be a subscription renewal or some other change, such as a change in the auto-renewal status of the subscription. Here, expiration is not considered a state update, as it happens based on time.", true, true, false)]
    public class PlayerEventIAPSubscriptionStateUpdated : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public InAppProductId ProductId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string OriginalTransactionId { get; set; }

        [FirebaseAnalyticsIgnore]
        [MetaMember(3, (MetaMemberFlags)0)]
        public SubscriptionInstanceState? SubscriptionInstanceState { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaTime OverallExpirationTime { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public SubscriptionRenewalStatus OverallRenewalStatus { get; set; }
        public override string EventDescription { get; }

        private PlayerEventIAPSubscriptionStateUpdated()
        {
        }

        public PlayerEventIAPSubscriptionStateUpdated(InAppProductId productId, string originalTransactionId, SubscriptionInstanceState? subscriptionInstanceState, MetaTime overallExpirationTime, SubscriptionRenewalStatus overallRenewalStatus)
        {
        }
    }
}