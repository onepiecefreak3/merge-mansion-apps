using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic;
using Metaplay.Core.Offers;

namespace Code.GameLogic.FlashSales
{
    public class FlashSalesGroupSource : IConfigItemSource<FlashSaleGroupDefinition, FlashSaleGroupId>, IGameConfigSourceItem<FlashSaleGroupId, FlashSaleGroupDefinition>, IHasGameConfigKey<FlashSaleGroupId>
    {
        public FlashSaleGroupId ConfigKey { get; set; }
        private FlashSaleSlotId SlotId { get; set; }
        private bool IgnoreRoll { get; set; }
        private int Weight { get; set; }
        private List<ShopItemId> Offer { get; set; }
        private List<string> RequirementType { get; set; }
        private List<string> RequirementId { get; set; }
        private List<string> RequirementAmount { get; set; }
        private List<string> RequirementAux0 { get; set; }
        private OfferPlacementId PlacementId { get; set; }

        public FlashSalesGroupSource()
        {
        }
    }
}