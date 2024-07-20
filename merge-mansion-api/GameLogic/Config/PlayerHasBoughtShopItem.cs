using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1022)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class PlayerHasBoughtShopItem : TypedPlayerPropertyId<int>
    {
        public override string DisplayName { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
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