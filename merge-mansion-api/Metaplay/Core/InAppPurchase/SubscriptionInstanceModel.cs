using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.InAppPurchase
{
    [MetaSerializable]
    public class SubscriptionInstanceModel
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime StateQueriedAt { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool StateWasAvailableAtLastQuery { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaTime? LastKnownStateQueriedAt { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public SubscriptionInstanceState? LastKnownState { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool DisabledDueToReuse { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public MetaTime ReuseCheckedAt { get; set; }

        private SubscriptionInstanceModel()
        {
        }

        public SubscriptionInstanceModel(MetaTime stateQueriedAt, SubscriptionInstanceState? state)
        {
        }
    }
}