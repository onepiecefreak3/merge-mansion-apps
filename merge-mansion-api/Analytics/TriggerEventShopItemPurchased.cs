using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.Model;
using GameLogic;
using System;

namespace Analytics
{
    [AnalyticsEvent(3045, "Shop item purchased", 1, null, false, false, true)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class TriggerEventShopItemPurchased : PlayerTriggerEvent
    {
        [Description("Purchased shop item")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("shop_item_id")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public string ShopItemId { get; set; }

        private TriggerEventShopItemPurchased()
        {
        }

        public TriggerEventShopItemPurchased(ShopItemId shopItemId)
        {
        }
    }
}