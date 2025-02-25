using Metaplay.Core.Model;
using GameLogic.Config.Shop.Items;
using System;
using GameLogic.Player;
using GameLogic.Player.Rewards;
using System.Runtime.CompilerServices;

namespace GameLogic.Shop
{
    [MetaSerializableDerived(4)]
    [MetaAllowNoSerializedMembers]
    public class FlashSaleItem : IShopItem
    {
        private Func<ValueTuple<Currencies, long>> HowMuchPlayerMustPay { get; set; }
        private Func<int> HowManyPlayerCanStillBuy { get; set; }
        private Action<IPlayer, IRewardContext> OnAfterPurchase { get; set; }

        public FlashSaleItem()
        {
        }

        public FlashSaleItem(int itemId, ValueTuple<Currencies, long> cost, Func<int> amountChecker, Action<IPlayer> afterPurchase)
        {
        }

        public PlayerReward Reward { get; set; }

        public FlashSaleItem(PlayerReward reward, Func<ValueTuple<Currencies, long>> priceGetter, Func<int> amountChecker, Action<IPlayer> afterPurchase)
        {
        }

        public ValueTuple<EnergyType, int, int> BonusEnergy { get; set; }

        public FlashSaleItem(PlayerReward reward, Func<ValueTuple<Currencies, long>> priceGetter, Func<int> amountChecker, Action<IPlayer> afterPurchase, ValueTuple<EnergyType, int, int> bonusEnergy)
        {
        }

        public ShopItemId ShopItemId { get; set; }

        public FlashSaleItem(PlayerReward reward, Func<ValueTuple<Currencies, long>> priceGetter, Func<int> amountChecker, Action<IPlayer> afterPurchase, ValueTuple<EnergyType, int, int> bonusEnergy, ShopItemId shopItemId)
        {
        }

        public bool IsPurchasedWithAds { get; set; }

        public FlashSaleItem(PlayerReward reward, Func<ValueTuple<Currencies, long>> priceGetter, Func<int> amountChecker, Action<IPlayer, IRewardContext> afterPurchase, ValueTuple<EnergyType, int, int> bonusEnergy, ShopItemId shopItemId)
        {
        }
    }
}