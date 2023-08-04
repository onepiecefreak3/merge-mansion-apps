using Metaplay.Core.Model;

namespace Metaplay.Core.InAppPurchase
{
    [MetaSerializable]
    public enum PendingPurchaseAnalyticsContextStatus
    {
        RequestedByClient = 0,
        ConfirmedByServer = 1
    }
}