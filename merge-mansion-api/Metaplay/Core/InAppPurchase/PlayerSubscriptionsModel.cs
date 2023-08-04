using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Metaplay.Core.InAppPurchase
{
    [MetaSerializable]
    public class PlayerSubscriptionsModel
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Dictionary<InAppProductId, SubscriptionModel> Subscriptions { get; set; }

        public PlayerSubscriptionsModel()
        {
        }
    }
}