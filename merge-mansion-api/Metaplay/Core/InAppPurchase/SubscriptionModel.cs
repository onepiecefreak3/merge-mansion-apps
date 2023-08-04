using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace Metaplay.Core.InAppPurchase
{
    [MetaSerializable]
    public class SubscriptionModel
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Dictionary<string, SubscriptionInstanceModel> SubscriptionInstances { get; set; }
        public MetaDuration ExpirationSafetyMargin { get; }
        private MetaTime StartTime { get; }
        private MetaTime ExpirationTime { get; }
        private SubscriptionRenewalStatus RenewalStatus { get; }
        private bool LatestInstanceIsDisabledDueToReuse { get; }

        public SubscriptionModel()
        {
        }
    }
}