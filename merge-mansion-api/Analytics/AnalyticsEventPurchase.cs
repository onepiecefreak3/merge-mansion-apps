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
        [JsonProperty("item_name")]
        [Description("ID of the purchased item")]
        public string ItemName { get; set; }

        [JsonProperty("iap_platform_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Platform identifier of the item.")]
        public string IapPlatformId { get; set; }

        [JsonProperty("index_of_purchase")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Indox of purchase in the list")]
        public int PurchaseIndex { get; set; }

        [JsonProperty("currency_cost")]
        [Description("Cost of purchase in currency")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public AnalyticsCurrencyCost CurrencyCost { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Purchase transaction ID")]
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [Description("IAP product ID")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("product_id")]
        public InAppProductId ProductId { get; set; }

        [JsonProperty("order_id")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("IAP order ID")]
        public string OrderId { get; set; }

        [JsonProperty("reference_price")]
        [Description("Reference price for the purchase")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public F64 ReferencePrice { get; set; }

        [JsonProperty("status")]
        [Description("Final status of the purchase")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public InAppPurchaseStatus Status { get; set; }

        [Description("Platform")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("iap_platform")]
        public InAppPurchasePlatform Platform { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("group_id")]
        [Description("Offer Group Id")]
        public MetaOfferGroupId GroupId { get; set; }

        [JsonProperty("placement")]
        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Placement of the purchase option on the client")]
        public string PlacementId { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        [JsonProperty("impression_id")]
        [Description("Impression id to connect impression with purchase")]
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

        [Description("The trigger that caused the offer impression")]
        [JsonProperty("trigger_type")]
        [MetaMember(16, (MetaMemberFlags)0)]
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