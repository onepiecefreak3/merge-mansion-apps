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

        [Description("ID of the purchased item")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Platform identifier of the item.")]
        [JsonProperty("iap_platform_id")]
        public string IapPlatformId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("index_of_purchase")]
        [Description("Indox of purchase in the list")]
        public int PurchaseIndex { get; set; }

        [Description("Cost of purchase in currency")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("currency_cost")]
        public AnalyticsCurrencyCost CurrencyCost { get; set; }

        [JsonProperty("transaction_id")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Purchase transaction ID")]
        public string TransactionId { get; set; }

        [JsonProperty("product_id")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("IAP product ID")]
        public InAppProductId ProductId { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("order_id")]
        [Description("IAP order ID")]
        public string OrderId { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("reference_price")]
        [Description("Reference price for the purchase")]
        public F64 ReferencePrice { get; set; }

        [JsonProperty("status")]
        [Description("Final status of the purchase")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public InAppPurchaseStatus Status { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Platform")]
        [JsonProperty("iap_platform")]
        public InAppPurchasePlatform Platform { get; set; }

        [Description("Offer Group Id")]
        [JsonProperty("group_id")]
        [MetaMember(12, (MetaMemberFlags)0)]
        public MetaOfferGroupId GroupId { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Placement of the purchase option on the client")]
        [JsonProperty("placement")]
        public string PlacementId { get; set; }

        [JsonProperty("impression_id")]
        [Description("Impression id to connect impression with purchase")]
        [MetaMember(14, (MetaMemberFlags)0)]
        public string ImpressionId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventPurchase()
        {
        }

        public AnalyticsEventPurchase(string itemName, string iapPlatformId, int purchaseIndex, AnalyticsCurrencyCost currencyCost, string transactionId, InAppProductId productId, string orderId, F64 referencePrice, InAppPurchaseStatus status, InAppPurchasePlatform platform, string placementId, MetaOfferGroupId groupId, string impressionId)
        {
        }

        [MetaMember(15, (MetaMemberFlags)0)]
        [Description("Players segment for the offer")]
        [JsonProperty("segment")]
        public PlayerSegmentId Segment { get; set; }

        [Description("The trigger that caused the offer impression")]
        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("trigger_type")]
        public string TriggerType { get; set; }

        [JsonProperty("offer_items")]
        [MetaMember(17, (MetaMemberFlags)0)]
        [Description("Array of rewards & their amount in the offer")]
        public string OfferItems { get; set; }

        public AnalyticsEventPurchase(string itemName, string iapPlatformId, int purchaseIndex, AnalyticsCurrencyCost currencyCost, string transactionId, InAppProductId productId, string orderId, F64 referencePrice, InAppPurchaseStatus status, InAppPurchasePlatform platform, string placementId, MetaOfferGroupId groupId, string impressionId, PlayerSegmentId segment, string triggerType, string offerItems)
        {
        }
    }
}