using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.InAppPurchase
{
    [MetaSerializable]
    public struct SubscriptionInstanceState
    {
        [MetaMember(5, (MetaMemberFlags)0)]
        public bool IsAcquiredViaFamilySharing { get; set; }

        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime StartTime { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime ExpirationTime { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public SubscriptionRenewalStatus RenewalStatus { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int NumPeriods { get; set; }
    }
}