using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(30)]
    public class RewardMysteryMachineCurrency : PlayerReward, ICurrencyReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Currencies Currency { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string PoolTag { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string SkinName { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int DisplayAmount { get; set; }

        public RewardMysteryMachineCurrency()
        {
        }

        public RewardMysteryMachineCurrency(Currencies currency, int amount, string poolTag, string skinName, CurrencySource source, int displayAmount)
        {
        }
    }
}