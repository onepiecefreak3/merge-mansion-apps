using Metaplay.Core.Model;
using GameLogic.Config.Shop.PriceCurves;
using GameLogic.Config.Shop.PurchaseLimiters;
using System;

namespace GameLogic.Config.Shop.Items
{
    [MetaSerializableDerived(7)]
    public class DiamondItem : IShopItem
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private ShopItemId ShopItemId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private IPriceCurve PriceCurve { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private IPurchaseLimiter PurchaseLimiter { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public long Amount { get; set; }

        private DiamondItem()
        {
        }

        public DiamondItem(ShopItemId shopItemId, IPriceCurve priceCurve, IPurchaseLimiter purchaseLimiter, long amount)
        {
        }
    }
}