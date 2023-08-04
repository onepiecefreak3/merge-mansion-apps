using Metaplay.Core.Model;

namespace GameLogic.Config.Shop.PurchaseLimiters
{
    [MetaSerializableDerived(6)]
    public class DailyNoLimitPurchaseLimiter : IPurchaseLimiter
    {
        public DailyNoLimitPurchaseLimiter()
        {
        }
    }
}