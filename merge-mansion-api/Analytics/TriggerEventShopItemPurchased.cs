using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.Model;
using GameLogic;

namespace Analytics
{
    [AnalyticsEvent(3045, "Shop item purchased", 1, null, false, false, true)]
    public class TriggerEventShopItemPurchased : PlayerTriggerEvent
    {
        [JsonProperty("shop_item_id")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [Description("Purchased shop item")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public ShopItemId ShopItemId { get; set; }

        private TriggerEventShopItemPurchased()
        {
        }

        public TriggerEventShopItemPurchased(ShopItemId shopItemId)
        {
        }
    }
}