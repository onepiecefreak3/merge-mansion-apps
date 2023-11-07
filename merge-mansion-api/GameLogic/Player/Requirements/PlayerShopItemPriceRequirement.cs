using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic.Config.Shop;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(23)]
    public class PlayerShopItemPriceRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MetaRef<ShopItemInfo> ShopItemInfoRef { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private float? MinPercentage { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private float? MaxPercentage { get; set; }

        public PlayerShopItemPriceRequirement()
        {
        }

        public PlayerShopItemPriceRequirement(ShopItemId shopItemId, float? minPercentage, float? maxPercentage)
        {
        }
    }
}