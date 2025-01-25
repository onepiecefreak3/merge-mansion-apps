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
        [MetaMember(2, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [Description("Purchased shop item")]
        [JsonProperty("shop_item_id")]
        public string ShopItemId { get; set; }

        private TriggerEventShopItemPurchased()
        {
        }

        public TriggerEventShopItemPurchased(ShopItemId shopItemId)
        {
        }
    }
}