using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Code.GameLogic.FlashSales;
using System;
using Metaplay.Core.Offers;

namespace GameLogic.Config.Shop
{
    public class FlashSaleShopSettingsSource : IConfigItemSource<FlashSaleShopSettings, FlashSaleShopSettingsId>, IGameConfigSourceItem<FlashSaleShopSettingsId, FlashSaleShopSettings>, IHasGameConfigKey<FlashSaleShopSettingsId>
    {
        public FlashSaleShopSettingsId ConfigKey { get; set; }
        public List<FlashSaleSlotId> ActiveFlashSaleSlots { get; set; }
        public Currencies FlashResetCurrency { get; set; }
        public List<int> FlashResetCosts { get; set; }
        public OfferPlacementId PlacementId { get; set; }

        public FlashSaleShopSettingsSource()
        {
        }

        public bool RefreshDisabled { get; set; }
    }
}