using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace GameLogic
{
    public class DynamicPurchaseDefinitionSource : IConfigItemSource<DynamicPurchaseDefinition, ShopItemId>, IGameConfigSourceItem<ShopItemId, DynamicPurchaseDefinition>, IHasGameConfigKey<ShopItemId>, IGameConfigData<ShopItemId>, IGameConfigData
    {
        private static HashSet<string> disallowedItems;
        private ShopItemId ShopItemId { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        public ShopItemId ConfigKey { get; }

        public DynamicPurchaseDefinitionSource()
        {
        }
    }
}