using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;
using GameLogic.Config.Costs;
using GameLogic;

namespace Analytics
{
    [MetaSerializableDerived(1)]
    [MetaBlockedMembers(new int[] { 3, 4, 1 })]
    public class AnalyticsFlashSaleImpressionItem : AnalyticsFlashSaleImpressionItemBase
    {
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("shop_item_id")]
        public string ShopItemId { get; set; }

        [JsonProperty("item_name")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string ItemType { get; set; }

        public AnalyticsFlashSaleImpressionItem()
        {
        }

        public AnalyticsFlashSaleImpressionItem(ShopItemId shopItemId, string itemType, ICost cost, int slotId)
        {
        }

        public AnalyticsFlashSaleImpressionItem(ShopItemId shopItemId, string itemType, ICost cost, int slotId, string attachment, int attachmentAmount)
        {
        }
    }
}