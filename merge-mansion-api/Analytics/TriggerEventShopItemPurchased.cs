using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.Model;
using GameLogic;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 1 })]
    [AnalyticsEvent(3045, "Shop item purchased", 1, null, false, false, true)]
    public class TriggerEventShopItemPurchased : PlayerTriggerEvent
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Purchased shop item")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("shop_item_id")]
        public ShopItemId ShopItemId { get; set; }

        private TriggerEventShopItemPurchased()
        {
        }

        public TriggerEventShopItemPurchased(ShopItemId shopItemId)
        {
        }
    }
}