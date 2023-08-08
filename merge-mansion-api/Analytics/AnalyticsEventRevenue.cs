using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [AnalyticsEvent(119, "Revenue event", 1, null, false, true, false)]
    [MetaBlockedMembers(new int[] { 2, 4 })]
    public class AnalyticsEventRevenue : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Display name of the IAP product")]
        [JsonProperty("item_name")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ItemName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Transaction to which revenue is attributed")]
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [Description("Order to which revenue is attributed")]
        [JsonProperty("order_id")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public string OrderId { get; set; }

        [JsonProperty("iap_platform_id")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Platform identifier of the item.")]
        public string PlatformId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventRevenue()
        {
        }

        public AnalyticsEventRevenue(string itemName, string transactionId, string orderId, string platformId)
        {
        }
    }
}