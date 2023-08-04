using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.InAppPurchase
{
    [MetaSerializable]
    public class SubscriptionQueryResult
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime StateQueriedAt { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public SubscriptionInstanceState? State { get; set; }

        [MetaMember(1, (MetaMemberFlags)0)]
        public string LegacyOriginalTransactionId { get; set; }

        private SubscriptionQueryResult()
        {
        }

        public SubscriptionQueryResult(MetaTime stateQueriedAt, SubscriptionInstanceState? state)
        {
        }
    }
}