using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 2, 4 })]
    [AnalyticsEvent(119, "Revenue event", 1, null, false, true, false)]
    public class AnalyticsEventRevenue : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("item_name")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Display name of the IAP product")]
        public string ItemName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Transaction to which revenue is attributed")]
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Order to which revenue is attributed")]
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("iap_platform_id")]
        [Description("Platform identifier of the item.")]
        [MetaMember(6, (MetaMemberFlags)0)]
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