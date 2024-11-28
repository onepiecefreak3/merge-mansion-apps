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

        [Description("ID of the purchased item")]
        [JsonProperty("item_name")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ItemName { get; set; }

        [Description("Platform identifier of the item.")]
        [JsonProperty("iap_platform_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string IapPlatformId { get; set; }

        [Description("Indox of purchase in the list")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("index_of_purchase")]
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
        [Description("IAP product ID")]
        [JsonProperty("product_id")]
        public InAppProductId ProductId { get; set; }

        [Description("IAP order ID")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [Description("Reference price for the purchase")]
        [JsonProperty("reference_price")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public F64 ReferencePrice { get; set; }

        [Description("Final status of the purchase")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("status")]
        public InAppPurchaseStatus Status { get; set; }

        [JsonProperty("iap_platform")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Platform")]
        public InAppPurchasePlatform Platform { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("Offer Group Id")]
        [JsonProperty("group_id")]
        public MetaOfferGroupId GroupId { get; set; }

        [JsonProperty("placement")]
        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Placement of the purchase option on the client")]
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

        [JsonProperty("segment")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [Description("Players segment for the offer")]
        public PlayerSegmentId Segment { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("trigger_type")]
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