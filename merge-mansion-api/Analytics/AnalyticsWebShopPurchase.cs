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
        [Description("ID of the purchased item")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("webshop_purchase_item_id")]
        public string WebShopPurchaseItemId;
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("ID of the WebShop purchase")]
        [JsonProperty("purchase_id")]
        public string PurchaseId;
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        public AnalyticsWebShopPurchase()
        {
        }
    }
}