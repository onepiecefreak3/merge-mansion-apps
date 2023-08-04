using Metaplay.Core.Model;

namespace GameLogic.Config.Shop.PurchaseLimiters
{
    [MetaSerializableDerived(1)]
    public class NoLimitPurchaseLimiter : IPurchaseLimiter
    {
        public NoLimitPurchaseLimiter()
        {
        }
    }
}