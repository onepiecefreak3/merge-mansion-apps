using Metaplay.Core.Model;
using Newtonsoft.Json;
using GameLogic.Player;
using System;
using GameLogic.Config.Costs;

namespace Analytics
{
    [MetaSerializableDerived(2)]
    public class AnalyticsFlashSaleImpressionEnergy : AnalyticsFlashSaleImpressionItemBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("shop_item_id")]
        public ShopItemId ShopItemId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("energy_type")]
        public EnergyType EnergyType { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("energy_amount")]
        public int EnergyAmount { get; set; }

        public AnalyticsFlashSaleImpressionEnergy()
        {
        }

        public AnalyticsFlashSaleImpressionEnergy(ShopItemId shopItemId, EnergyType energyType, int energyAmount, ICost cost, int slotId)
        {
        }
    }
}