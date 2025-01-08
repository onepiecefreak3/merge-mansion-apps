using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;
using GameLogic.Config.Costs;
using GameLogic;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 3, 4, 1 })]
    [MetaSerializableDerived(1)]
    public class AnalyticsFlashSaleImpressionItem : AnalyticsFlashSaleImpressionItemBase
    {
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("shop_item_id")]
        public string ShopItemId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("item_name")]
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