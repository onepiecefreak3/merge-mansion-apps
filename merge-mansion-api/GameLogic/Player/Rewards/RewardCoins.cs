using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(1)]
    [MetaBlockedMembers(new int[] { 2 })]
    public class RewardCoins : PlayerReward, ICurrencyReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        [JsonIgnore]
        public Currencies Currency { get; }

        public RewardCoins()
        {
        }

        public RewardCoins(int amount, CurrencySource currencySource)
        {
        }
    }
}