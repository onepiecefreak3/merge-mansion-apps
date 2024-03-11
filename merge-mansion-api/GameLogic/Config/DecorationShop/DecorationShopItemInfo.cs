using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Metaplay.Core;
using GameLogic.Decorations;
using System.Collections.Generic;
using GameLogic.Config.Costs;

namespace GameLogic.Config.DecorationShop
{
    [MetaSerializable]
    public class DecorationShopItemInfo : IGameConfigData<DecorationShopItemId>, IGameConfigData, IHasGameConfigKey<DecorationShopItemId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DecorationShopItemId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaRef<DecorationInfo> DecorationRef { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<ICost> Costs { get; set; }

        public DecorationShopItemInfo()
        {
        }

        public DecorationShopItemInfo(DecorationShopItemId configKey, MetaRef<DecorationInfo> decorationRef, IEnumerable<ICost> costs)
        {
        }
    }
}