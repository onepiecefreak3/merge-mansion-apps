using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic.Config.Shop;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(55)]
    public class PlayerCanAffordShopItemRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MetaRef<ShopItemInfo> ShopItemInfoRef { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private bool CanAfford { get; set; }

        public PlayerCanAffordShopItemRequirement()
        {
        }

        public PlayerCanAffordShopItemRequirement(ShopItemId shopItemId, bool canAfford)
        {
        }
    }
}