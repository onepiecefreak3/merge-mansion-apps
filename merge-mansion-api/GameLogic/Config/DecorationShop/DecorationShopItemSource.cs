using Code.GameLogic.Config;
using Metaplay.Core.Config;
using Metaplay.Core;
using GameLogic.Decorations;
using System.Collections.Generic;
using System;

namespace GameLogic.Config.DecorationShop
{
    public class DecorationShopItemSource : IConfigItemSource<DecorationShopItemInfo, DecorationShopItemId>, IGameConfigSourceItem<DecorationShopItemId, DecorationShopItemInfo>, IHasGameConfigKey<DecorationShopItemId>
    {
        public DecorationShopItemId ConfigKey { get; set; }
        private MetaRef<DecorationInfo> Decoration { get; set; }
        private List<string> CostCurrency { get; set; }
        private List<int> CostAmount { get; set; }

        public DecorationShopItemSource()
        {
        }
    }
}