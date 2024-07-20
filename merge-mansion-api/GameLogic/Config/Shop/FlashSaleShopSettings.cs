using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Code.GameLogic.FlashSales;
using System;
using Metaplay.Core.Offers;

namespace GameLogic.Config.Shop
{
    [MetaSerializable]
    public class FlashSaleShopSettings : IGameConfigData<FlashSaleShopSettingsId>, IGameConfigData, IHasGameConfigKey<FlashSaleShopSettingsId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public FlashSaleShopSettingsId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<FlashSaleSlotId> ActiveFlashSaleSlots { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public Currencies FlashResetCurrency { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<int> FlashResetCosts { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public OfferPlacementId PlacementId { get; set; }

        public FlashSaleShopSettings()
        {
        }

        public FlashSaleShopSettings(FlashSaleShopSettingsId flashSaleShopSettingsId, List<FlashSaleSlotId> activeFlashSaleSlots, Currencies flashResetCurrency, List<int> flashResetCosts, OfferPlacementId placementId)
        {
        }
    }
}