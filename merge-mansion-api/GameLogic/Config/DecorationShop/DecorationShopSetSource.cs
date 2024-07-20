using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;

namespace GameLogic.Config.DecorationShop
{
    public class DecorationShopSetSource : IConfigItemSource<DecorationShopSetInfo, DecorationShopSetId>, IGameConfigSourceItem<DecorationShopSetId, DecorationShopSetInfo>, IHasGameConfigKey<DecorationShopSetId>
    {
        public DecorationShopSetId ConfigKey { get; set; }
        private string NameLocId { get; set; }
        private List<MetaRef<DecorationShopItemInfo>> Items { get; set; }

        public DecorationShopSetSource()
        {
        }
    }
}