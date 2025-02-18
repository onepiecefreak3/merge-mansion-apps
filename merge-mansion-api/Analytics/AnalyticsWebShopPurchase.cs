using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using System;

namespace Analytics
{
    [AnalyticsEvent(184, "WebShop purchase", 1, null, false, true, false)]
    public class AnalyticsWebShopPurchase : AnalyticsServersideEventBase
    {
        [JsonProperty("webshop_purchase_item_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("ID of the purchased item")]
        public string WebShopPurchaseItemId;
        [Description("ID of the WebShop purchase")]
        [JsonProperty("purchase_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string PurchaseId;
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        public AnalyticsWebShopPurchase()
        {
        }
    }
}