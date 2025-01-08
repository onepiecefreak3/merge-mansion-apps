using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaBlockedMembers(new int[] { 1 })]
    [MetaSerializableDerived(1022)]
    public class PlayerHasBoughtShopItem : TypedPlayerPropertyId<int>
    {
        public override string DisplayName { get; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private ShopItemId ShopItemId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private int Days { get; set; }

        private PlayerHasBoughtShopItem()
        {
        }

        public PlayerHasBoughtShopItem(ShopItemId shopItemId, int days)
        {
        }
    }
}