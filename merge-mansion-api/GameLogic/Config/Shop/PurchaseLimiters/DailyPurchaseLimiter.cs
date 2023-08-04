using Metaplay.Core.Model;
using System;

namespace GameLogic.Config.Shop.PurchaseLimiters
{
    [MetaSerializableDerived(3)]
    public class DailyPurchaseLimiter : IPurchaseLimiter
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int PurchasesPerDay { get; set; }

        public DailyPurchaseLimiter()
        {
        }

        public DailyPurchaseLimiter(int purchasesPerDay)
        {
        }
    }
}