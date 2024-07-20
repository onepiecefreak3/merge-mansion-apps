using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;
using Merge;
using Metaplay.Core.Math;
using System.Collections.Generic;
using Metaplay.Core.Player;

namespace GameLogic.Config.Shop
{
    public class ShopItemInfoSource : IConfigItemSource<ShopItemInfo, ShopItemId>, IGameConfigSourceItem<ShopItemId, ShopItemInfo>, IHasGameConfigKey<ShopItemId>
    {
        private ShopItemId ShopItemId { get; set; }
        private ShopCategoryId ShopCategory { get; set; }
        private string Type { get; set; }
        private MetaRef<InAppProductInfo> InAppProduct { get; set; }
        private string Item { get; set; }
        private long Quantity { get; set; }
        private MergeBoardId BoardId { get; set; }
        private string PurchaseLimitType { get; set; }
        private int MaxPurchases { get; set; }
        private string PriceCurveType { get; set; }
        private Currencies PriceCurveCurrency { get; set; }
        private F64 PriceCurveMax { get; set; }
        private F64 PriceCurveBase { get; set; }
        private F64 PriceCurveIncrement { get; set; }
        private List<string> RequirementType { get; set; }
        private List<string> RequirementId { get; set; }
        private List<string> RequirementAmount { get; set; }
        private List<string> RequirementAux0 { get; set; }
        private int PurchaseLimitTimeAmount { get; set; }
        private string PurchaseLimitAux0 { get; set; }
        private List<MetaRef<PlayerSegmentInfoBase>> Segments { get; set; }
        private bool IsUnderMore { get; set; }
        private bool ForWebshop { get; set; }
        public ShopItemId ConfigKey { get; }

        public ShopItemInfoSource()
        {
        }
    }
}