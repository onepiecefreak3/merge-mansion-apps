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
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("purchase_id")]
        [Description("ID of the WebShop purchase")]
        public string PurchaseId;
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        public AnalyticsWebShopPurchase()
        {
        }
    }
}