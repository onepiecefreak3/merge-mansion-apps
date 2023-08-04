using Metaplay.Core.Model;
using System;

namespace GameLogic.Config.Shop.PurchaseLimiters
{
    [MetaSerializableDerived(8)]
    public class DailyMaxOverNDaysPurchaseLimiter : IPurchaseLimiter
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int PurchasesPerDay { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private int Days { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private int MaxPurchasesOverDays { get; set; }

        public DailyMaxOverNDaysPurchaseLimiter()
        {
        }

        public DailyMaxOverNDaysPurchaseLimiter(int purchasesPerDay, int days, int maxPurchasesOverDays)
        {
        }
    }
}