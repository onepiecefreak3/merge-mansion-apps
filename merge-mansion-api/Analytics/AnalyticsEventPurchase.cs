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

        [Description("Platform identifier of the item.")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("iap_platform_id")]
        public string IapPlatformId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Indox of purchase in the list")]
        [JsonProperty("index_of_purchase")]
        public int PurchaseIndex { get; set; }

        [Description("Cost of purchase in currency")]
        [JsonProperty("currency_cost")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public AnalyticsCurrencyCost CurrencyCost { get; set; }

        [JsonProperty("transaction_id")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Purchase transaction ID")]
        public string TransactionId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("IAP product ID")]
        [JsonProperty("product_id")]
        public InAppProductId ProductId { get; set; }

        [Description("IAP order ID")]
        [JsonProperty("order_id")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public string OrderId { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Reference price for the purchase")]
        [JsonProperty("reference_price")]
        public F64 ReferencePrice { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Final status of the purchase")]
        [JsonProperty("status")]
        public InAppPurchaseStatus Status { get; set; }

        [JsonProperty("iap_platform")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Platform")]
        public InAppPurchasePlatform Platform { get; set; }

        [Description("Offer Group Id")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("group_id")]
        public MetaOfferGroupId GroupId { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Placement of the purchase option on the client")]
        [JsonProperty("placement")]
        public string PlacementId { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        [Description("Impression id to connect impression with purchase")]
        [JsonProperty("impression_id")]
        public string ImpressionId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventPurchase()
        {
        }

        public AnalyticsEventPurchase(string itemName, string iapPlatformId, int purchaseIndex, AnalyticsCurrencyCost currencyCost, string transactionId, InAppProductId productId, string orderId, F64 referencePrice, InAppPurchaseStatus status, InAppPurchasePlatform platform, string placementId, MetaOfferGroupId groupId, string impressionId)
        {
        }

        [JsonProperty("segment")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [Description("Players segment for the offer")]
        public PlayerSegmentId Segment { get; set; }

        [JsonProperty("trigger_type")]
        [MetaMember(16, (MetaMemberFlags)0)]
        [Description("The trigger that caused the offer impression")]
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