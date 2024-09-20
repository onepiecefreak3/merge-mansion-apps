using Code.GameLogic.Config;
using GameLogic;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Config;
using Metaplay.Core.Player;

namespace Code.GameLogic.FlashSales
{
    public class FlashSaleSource : IConfigItemSource<FlashSaleDefinition, ShopItemId>, IGameConfigSourceItem<ShopItemId, FlashSaleDefinition>, IHasGameConfigKey<ShopItemId>
    {
        public ShopItemId ConfigKey { get; set; }
        private int Quantity { get; set; }
        private int Weight { get; set; }
        private string PriceCurrency { get; set; }
        private string PriceAmount { get; set; }
        private string RewardType { get; set; }
        private string RewardId { get; set; }
        private string RewardAux0 { get; set; }
        private string RewardAux1 { get; set; }
        private int RewardAmount { get; set; }
        private List<string> RequirementType { get; set; }
        private List<string> RequirementId { get; set; }
        private List<string> RequirementAmount { get; set; }
        private List<string> RequirementAux0 { get; set; }

        public FlashSaleSource()
        {
        }

        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
    }
}