using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;

namespace GameLogic.Config.DecorationShop
{
    [MetaSerializable]
    public class DecorationShopSetInfo : IGameConfigData<DecorationShopSetId>, IGameConfigData, IHasGameConfigKey<DecorationShopSetId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DecorationShopSetId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string NameLocId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<MetaRef<DecorationShopItemInfo>> ItemRefs { get; set; }

        public DecorationShopSetInfo()
        {
        }

        public DecorationShopSetInfo(DecorationShopSetId configKey, string nameLocId, List<MetaRef<DecorationShopItemInfo>> itemRefs)
        {
        }
    }
}