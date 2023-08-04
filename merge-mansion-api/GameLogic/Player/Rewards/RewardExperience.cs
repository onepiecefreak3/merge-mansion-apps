using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(2)]
    [MetaSerializable]
    public class RewardExperience : PlayerReward, ICurrencyReward
    {
        [MetaMember(1, 0)]
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