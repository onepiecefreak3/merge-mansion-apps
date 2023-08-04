using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.Player.Requirements;
using GameLogic.Config.Shop.Items;
using System.Collections.Generic;

namespace GameLogic.Config.Shop
{
    [MetaSerializable]
    public class ShopItemInfo : IGameConfigData<ShopItemId>, IGameConfigData, IHasRequirements, IShopItemInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ShopItemId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public ShopCategoryId ShopCategory { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public IShopItem ActualItem { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<PlayerRequirement> RequirementsList { get; set; }
        public List<PlayerRequirement> Requirements { get; }

        public ShopItemInfo()
        {
        }

        public ShopItemInfo(ShopItemId configKey, ShopCategoryId shopCategory, IShopItem actualItem, List<PlayerRequirement> requirements)
        {
        }
    }
}