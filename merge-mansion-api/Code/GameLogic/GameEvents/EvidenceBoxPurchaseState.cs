using Metaplay.Core.Model;
using System;
using Metaplay.Core;
using GameLogic.CardCollection;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EvidenceBoxPurchaseState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int PurchaseCount { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime NextTimerReset { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private MetaTime LastPurchaseCycleEndTime { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public CurrencyPricePair CurrentSkipTimePrice { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MetaTime LastPurchaseTime { get; set; }

        public EvidenceBoxPurchaseState()
        {
        }
    }
}