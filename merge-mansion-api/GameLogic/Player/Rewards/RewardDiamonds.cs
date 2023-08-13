using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(3)]
    [MetaBlockedMembers(new int[] { 2 })]
    public class RewardDiamonds : PlayerReward, ICurrencyReward
    {
        [MetaMember(1, 0)]
        public int Amount { get; set; }

        [JsonIgnore]
        public Currencies Currency { get; }

        public RewardDiamonds()
        {
        }

        public RewardDiamonds(int amount, CurrencySource currencySource)
        {
        }
    }
}