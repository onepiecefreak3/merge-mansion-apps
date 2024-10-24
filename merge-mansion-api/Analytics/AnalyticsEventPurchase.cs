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
        [JsonProperty("item_name")]
        [MetaMember(1, (MetaMemberFlags)0)]
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
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("currency_cost")]
        public AnalyticsCurrencyCost CurrencyCost { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Purchase transaction ID")]
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("product_id")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("IAP product ID")]
        public InAppProductId ProductId { get; set; }

        [JsonProperty("order_id")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("IAP order ID")]
        public string OrderId { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("reference_price")]
        [Description("Reference price for the purchase")]
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

        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Placement of the purchase option on the client")]
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
        [MetaMember(16, (MetaMemberFlags)0)]
        [Description("The trigger that caused the offer impression")]
        public string TriggerType { get; set; }

        [Description("Array of rewards & their amount in the offer")]
        [MetaMember(17, (MetaMemberFlags)0)]
        [JsonProperty("offer_items")]
        public string OfferItems { get; set; }

        public AnalyticsEventPurchase(string itemName, string iapPlatformId, int purchaseIndex, AnalyticsCurrencyCost currencyCost, string transactionId, InAppProductId productId, string orderId, F64 referencePrice, InAppPurchaseStatus status, InAppPurchasePlatform platform, string placementId, MetaOfferGroupId groupId, string impressionId, PlayerSegmentId segment, string triggerType, string offerItems)
        {
        }
    }
}