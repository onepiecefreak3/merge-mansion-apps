using Metaplay.Core.Model;
using GameLogic.Config.Shop.PriceCurves;
using GameLogic.Config.Shop.PurchaseLimiters;
using System;
using GameLogic.Player;

namespace GameLogic.Config.Shop.Items
{
    [MetaSerializableDerived(3)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class EnergyItem : IShopItem
    {
        [MetaMember(6, (MetaMemberFlags)0)]
        private ShopItemId ShopItemId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private IPriceCurve PriceCurve { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private IPurchaseLimiter PurchaseLimiter { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public long EnergyAmount { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public EnergyType EnergyType { get; set; }

        private EnergyItem()
        {
        }

        public EnergyItem(ShopItemId shopItemId, IPriceCurve priceCurve, IPurchaseLimiter purchaseLimiter, EnergyType energyType, long energyAmount)
        {
        }
    }
}