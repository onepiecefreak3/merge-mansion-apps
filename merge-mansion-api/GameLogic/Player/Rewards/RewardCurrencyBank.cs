using GameLogic.Banks;
using Metaplay.Core.Model;
using System;
using Metaplay.Core.Forms;

namespace GameLogic.Player.Rewards
{
    [MetaFormHidden]
    [MetaSerializableDerived(19)]
    public class RewardCurrencyBank : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CurrencyBankId CurrencyBankId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int StoredAmount { get; set; }

        public RewardCurrencyBank()
        {
        }

        public RewardCurrencyBank(CurrencyBankId currencyBankId, int storedAmount)
        {
        }
    }
}