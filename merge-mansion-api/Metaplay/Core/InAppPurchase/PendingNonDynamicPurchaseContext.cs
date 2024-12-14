using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.InAppPurchase
{
    [MetaSerializable]
    public class PendingNonDynamicPurchaseContext
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string GameProductAnalyticsId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public PurchaseAnalyticsContext GameAnalyticsContext;
        [MetaMember(3, (MetaMemberFlags)0)]
        public string DeviceId;
        [MetaMember(4, (MetaMemberFlags)0)]
        [Transient]
        [NoChecksum]
        public PendingPurchaseAnalyticsContextStatus Status;
        private PendingNonDynamicPurchaseContext()
        {
        }

        public PendingNonDynamicPurchaseContext(string gameProductAnalyticsId, PurchaseAnalyticsContext gameAnalyticsContext, string deviceId, PendingPurchaseAnalyticsContextStatus status)
        {
        }
    }
}