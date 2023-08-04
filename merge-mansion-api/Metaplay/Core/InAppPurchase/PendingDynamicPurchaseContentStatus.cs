using Metaplay.Core.Model;

namespace Metaplay.Core.InAppPurchase
{
    [MetaSerializable]
    public enum PendingDynamicPurchaseContentStatus
    {
        RequestedByClient = 0,
        ConfirmedByServer = 1
    }
}