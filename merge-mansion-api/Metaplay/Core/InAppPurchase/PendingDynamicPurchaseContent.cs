using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.InAppPurchase
{
    [MetaSerializable]
    public class PendingDynamicPurchaseContent
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DynamicPurchaseContent Content;
        [MetaMember(3, (MetaMemberFlags)0)]
        public string DeviceId;
        [NoChecksum]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Transient]
        public PendingDynamicPurchaseContentStatus Status;
        [MetaMember(4, (MetaMemberFlags)0)]
        public string GameProductAnalyticsId;
        [MetaMember(5, (MetaMemberFlags)0)]
        public PurchaseAnalyticsContext GameAnalyticsContext;
        public PendingDynamicPurchaseContent()
        {
        }

        public PendingDynamicPurchaseContent(DynamicPurchaseContent content, string deviceId, string gameProductAnalyticsId, PurchaseAnalyticsContext gameAnalyticsContext, PendingDynamicPurchaseContentStatus status)
        {
        }
    }
}