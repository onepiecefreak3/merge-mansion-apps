using Metaplay.Core.Model;
using Newtonsoft.Json;
using GameLogic.Player;
using System;
using GameLogic.Config.Costs;
using GameLogic;

namespace Analytics
{
    [MetaSerializableDerived(2)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class AnalyticsFlashSaleImpressionEnergy : AnalyticsFlashSaleImpressionItemBase
    {
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("shop_item_id")]
        public string ShopItemId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("energy_type")]
        public EnergyType EnergyType { get; set; }

        [JsonProperty("energy_amount")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public int EnergyAmount { get; set; }

        public AnalyticsFlashSaleImpressionEnergy()
        {
        }

        public AnalyticsFlashSaleImpressionEnergy(ShopItemId shopItemId, EnergyType energyType, int energyAmount, ICost cost, int slotId)
        {
        }

        public AnalyticsFlashSaleImpressionEnergy(ShopItemId shopItemId, EnergyType energyType, int energyAmount, ICost cost, int slotId, string attachment, int attachmentAmount)
        {
        }
    }
}