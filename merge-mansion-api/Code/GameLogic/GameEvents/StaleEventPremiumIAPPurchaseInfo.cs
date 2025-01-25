using Metaplay.Core.Model;
using System;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class StaleEventPremiumIAPPurchaseInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string EventId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime ClaimTime;
        private StaleEventPremiumIAPPurchaseInfo()
        {
        }

        public StaleEventPremiumIAPPurchaseInfo(string eventId, MetaTime claimTime)
        {
        }
    }
}