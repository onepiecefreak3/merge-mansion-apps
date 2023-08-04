using Metaplay.Core.Model;

namespace GameLogic.Config.Shop.PurchaseLimiters
{
    [MetaSerializableDerived(4)]
    public class NoLimitButRecordPurchaseLimiter : IPurchaseLimiter
    {
        public NoLimitButRecordPurchaseLimiter()
        {
        }
    }
}