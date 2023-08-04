using Metaplay.Core.Model;

namespace Metaplay.Core.InAppPurchase
{
    [MetaSerializable]
    public enum SubscriptionRenewalStatus
    {
        Unknown = 0,
        NotExpectedToRenew = 1,
        ExpectedToRenew = 2
    }
}