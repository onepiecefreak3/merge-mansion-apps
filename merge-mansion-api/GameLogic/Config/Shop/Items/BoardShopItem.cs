using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic.Player.Items;
using Merge;
using GameLogic.Config.Shop.PriceCurves;
using GameLogic.Config.Shop.PurchaseLimiters;
using System;

namespace GameLogic.Config.Shop.Items
{
    [MetaBlockedMembers(new int[] { 1 })]
    [MetaSerializableDerived(2)]
    public class BoardShopItem : IShopItem
    {
        [MetaMember(6, (MetaMemberFlags)0)]
        private ShopItemId ShopItemId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private MetaRef<ItemDefinition> ItemRef { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private MergeBoardId BoardId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private IPriceCurve PriceCurve { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        private IPurchaseLimiter PurchaseLimiter { get; set; }
        public ItemDefinition Item { get; }

        private BoardShopItem()
        {
        }

        public BoardShopItem(ShopItemId shopItemId, int item, MergeBoardId mergeBoardId, IPriceCurve priceCurve, IPurchaseLimiter purchaseLimiter)
        {
        }

        public bool IsPurchasedWithAds { get; set; }
    }
}