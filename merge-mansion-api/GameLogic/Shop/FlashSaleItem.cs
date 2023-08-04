using Metaplay.Core.Model;
using GameLogic.Config.Shop.Items;
using System;
using GameLogic.Player;

namespace GameLogic.Shop
{
    [MetaAllowNoSerializedMembers]
    [MetaSerializableDerived(4)]
    public class FlashSaleItem : IShopItem
    {
        private int ItemType { get; set; }
        private (Currencies currency, long price) HowMuchPlayerMustPay { get; set; }
        private Func<int> HowManyPlayerCanStillBuy { get; set; }
        private Action<IPlayer> OnAfterPurchase { get; set; }

        public FlashSaleItem()
        {
        }

        public FlashSaleItem(int itemId, ValueTuple<Currencies, long> cost, Func<int> amountChecker, Action<IPlayer> afterPurchase)
        {
        }
    }
}