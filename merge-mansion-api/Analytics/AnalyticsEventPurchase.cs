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
    [AnalyticsEvent(118, "IAP purchase event", 1, null, false, true, false)]
    [MetaBlockedMembers(new int[] { 11 })]
    public class AnalyticsEventPurchase : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("item_name")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("ID of the purchased item")]
        public string ItemName { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Platform identifier of the item.")]
        [JsonProperty("iap_platform_id")]
        public string IapPlatformId { get; set; }

        [JsonProperty("index_of_purchase")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Indox of purchase in the list")]
        public int PurchaseIndex { get; set; }

        [Description("Cost of purchase in currency")]
        [JsonProperty("currency_cost")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public AnalyticsCurrencyCost CurrencyCost { get; set; }

        [JsonProperty("transaction_id")]
        [Description("Purchase transaction ID")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public string TransactionId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("product_id")]
        [Description("IAP product ID")]
        public InAppProductId ProductId { get; set; }

        [Description("IAP order ID")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [Description("Reference price for the purchase")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("reference_price")]
        public F64 ReferencePrice { get; set; }

        [JsonProperty("status")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Final status of the purchase")]
        public InAppPurchaseStatus Status { get; set; }

        [JsonProperty("iap_platform")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Platform")]
        public InAppPurchasePlatform Platform { get; set; }

        [JsonProperty("group_id")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("Offer Group Id")]
        public MetaOfferGroupId GroupId { get; set; }

        [JsonProperty("placement")]
        [Description("Placement of the purchase option on the client")]
        [MetaMember(13, (MetaMemberFlags)0)]
        public string PlacementId { get; set; }

        [JsonProperty("impression_id")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [Description("Impression id to connect impression with purchase")]
        public string ImpressionId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventPurchase()
        {
        }

        public AnalyticsEventPurchase(string itemName, string iapPlatformId, int purchaseIndex, AnalyticsCurrencyCost currencyCost, string transactionId, InAppProductId productId, string orderId, F64 referencePrice, InAppPurchaseStatus status, InAppPurchasePlatform platform, string placementId, MetaOfferGroupId groupId, string impressionId)
        {
        }

        [Description("Players segment for the offer")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [JsonProperty("segment")]
        public PlayerSegmentId Segment { get; set; }

        [Description("The trigger that caused the offer impression")]
        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("trigger_type")]
        public string TriggerType { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        [JsonProperty("offer_items")]
        [Description("Array of rewards & their amount in the offer")]
        public string OfferItems { get; set; }

        public AnalyticsEventPurchase(string itemName, string iapPlatformId, int purchaseIndex, AnalyticsCurrencyCost currencyCost, string transactionId, InAppProductId productId, string orderId, F64 referencePrice, InAppPurchaseStatus status, InAppPurchasePlatform platform, string placementId, MetaOfferGroupId groupId, string impressionId, PlayerSegmentId segment, string triggerType, string offerItems)
        {
        }
    }
}