using Metaplay.Core.Model;
using Metaplay.Core.Analytics;
using System.ComponentModel;
using Newtonsoft.Json;
using System;
using Metaplay.Core.InAppPurchase;
using Metaplay.Core.Math;
using Metaplay.Core.Offers;
using Metaplay.Core.Player;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 11 })]
    [AnalyticsEvent(118, "IAP purchase event", 1, null, false, true, false)]
    public class AnalyticsEventPurchase : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("ID of the purchased item")]
        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [Description("Platform identifier of the item.")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("iap_platform_id")]
        public string IapPlatformId { get; set; }

        [Description("Indox of purchase in the list")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("index_of_purchase")]
        public int PurchaseIndex { get; set; }

        [Description("Cost of purchase in currency")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("currency_cost")]
        public AnalyticsCurrencyCost CurrencyCost { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("transaction_id")]
        [Description("Purchase transaction ID")]
        public string TransactionId { get; set; }

        [JsonProperty("product_id")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("IAP product ID")]
        public InAppProductId ProductId { get; set; }

        [JsonProperty("order_id")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("IAP order ID")]
        public string OrderId { get; set; }

        [JsonProperty("reference_price")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Reference price for the purchase")]
        public F64 ReferencePrice { get; set; }

        [JsonProperty("status")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Final status of the purchase")]
        public InAppPurchaseStatus Status { get; set; }

        [Description("Platform")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("iap_platform")]
        public InAppPurchasePlatform Platform { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("group_id")]
        [Description("Offer Group Id")]
        public MetaOfferGroupId GroupId { get; set; }

        [Description("Placement of the purchase option on the client")]
        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("placement")]
        public string PlacementId { get; set; }

        [Description("Impression id to connect impression with purchase")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [JsonProperty("impression_id")]
        public string ImpressionId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventPurchase()
        {
        }

        public AnalyticsEventPurchase(string itemName, string iapPlatformId, int purchaseIndex, AnalyticsCurrencyCost currencyCost, string transactionId, InAppProductId productId, string orderId, F64 referencePrice, InAppPurchaseStatus status, InAppPurchasePlatform platform, string placementId, MetaOfferGroupId groupId, string impressionId)
        {
        }

        [MetaMember(15, (MetaMemberFlags)0)]
        [JsonProperty("segment")]
        [Description("Players segment for the offer")]
        public PlayerSegmentId Segment { get; set; }

        [JsonProperty("trigger_type")]
        [Description("The trigger that caused the offer impression")]
        [MetaMember(16, (MetaMemberFlags)0)]
        public string TriggerType { get; set; }

        [JsonProperty("offer_items")]
        [Description("Array of rewards & their amount in the offer")]
        [MetaMember(17, (MetaMemberFlags)0)]
        public string OfferItems { get; set; }

        public AnalyticsEventPurchase(string itemName, string iapPlatformId, int purchaseIndex, AnalyticsCurrencyCost currencyCost, string transactionId, InAppProductId productId, string orderId, F64 referencePrice, InAppPurchaseStatus status, InAppPurchasePlatform platform, string placementId, MetaOfferGroupId groupId, string impressionId, PlayerSegmentId segment, string triggerType, string offerItems)
        {
        }
    }
}