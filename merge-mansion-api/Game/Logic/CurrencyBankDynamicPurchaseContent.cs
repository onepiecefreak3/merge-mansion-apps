using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using GameLogic.Banks;
using System;
using System.Collections.Generic;
using Metaplay.Core.Rewards;

namespace Game.Logic
{
    [MetaSerializableDerived(4)]
    public class CurrencyBankDynamicPurchaseContent : DynamicPurchaseContent
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CurrencyBankId CurrencyBankId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int StoredAmount { get; set; }
        public override List<MetaPlayerRewardBase> PurchaseRewards { get; }

        private CurrencyBankDynamicPurchaseContent()
        {
        }

        public CurrencyBankDynamicPurchaseContent(CurrencyBankId currencyBankId, int storedAmount)
        {
        }
    }
}