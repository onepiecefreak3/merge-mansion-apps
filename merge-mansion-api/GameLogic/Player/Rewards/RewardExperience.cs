using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaBlockedMembers(new int[] { 2 })]
    [MetaSerializableDerived(2)]
    public class RewardExperience : PlayerReward, ICurrencyReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        [JsonIgnore]
        public Currencies Currency { get; }

        public RewardExperience()
        {
        }

        public RewardExperience(int amount, CurrencySource currencySource)
        {
        }
    }
}