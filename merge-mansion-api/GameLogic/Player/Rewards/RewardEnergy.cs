using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(5)]
    [MetaBlockedMembers(new int[] { 2 })]
    public class RewardEnergy : PlayerReward, ICurrencyReward
    {
        [MetaMember(1, 0)]
        public int Amount { get; set; }

        [JsonIgnore]
        public Currencies Currency { get; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public EnergyType EnergyType { get; set; }

        public RewardEnergy()
        {
        }

        public RewardEnergy(EnergyType energyType, int amount, CurrencySource currencySource)
        {
        }
    }
}