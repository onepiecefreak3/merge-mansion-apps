using Metaplay.Core.Model;
using System;

namespace GameLogic.Config.Shop.PurchaseLimiters
{
    [MetaSerializableDerived(9)]
    public class LifetimeLimitPurchaseLimiter : IPurchaseLimiter
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int MaxPurchases { get; set; }

        public LifetimeLimitPurchaseLimiter()
        {
        }

        public LifetimeLimitPurchaseLimiter(int maxPurchases)
        {
        }
    }
}