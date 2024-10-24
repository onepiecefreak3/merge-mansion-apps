using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.Model;
using GameLogic;

namespace Analytics
{
    [AnalyticsEvent(3045, "Shop item purchased", 1, null, false, false, true)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class TriggerEventShopItemPurchased : PlayerTriggerEvent
    {
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("shop_item_id")]
        [Description("Purchased shop item")]
        public ShopItemId ShopItemId { get; set; }

        private TriggerEventShopItemPurchased()
        {
        }

        public TriggerEventShopItemPurchased(ShopItemId shopItemId)
        {
        }
    }
}