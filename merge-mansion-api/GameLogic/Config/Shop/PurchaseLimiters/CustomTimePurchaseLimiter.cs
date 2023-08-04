using Metaplay.Core.Model;
using System;

namespace GameLogic.Config.Shop.PurchaseLimiters
{
    [MetaSerializableDerived(7)]
    public class CustomTimePurchaseLimiter : IPurchaseLimiter
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int PurchasesPerLimit { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private int PurchaseTimeLimitAmount { get; set; }

        public CustomTimePurchaseLimiter()
        {
        }

        public CustomTimePurchaseLimiter(int purchasesPerLimit, int purchaseTimeLimitAmount)
        {
        }
    }
}