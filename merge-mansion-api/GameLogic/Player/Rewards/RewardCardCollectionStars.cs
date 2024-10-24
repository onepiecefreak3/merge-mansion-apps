using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaBlockedMembers(new int[] { 2 })]
    [MetaSerializableDerived(41)]
    public class RewardCardCollectionStars : PlayerReward, ICurrencyReward
    {
        [JsonIgnore]
        public Currencies Currency { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        [JsonIgnore]
        public int DisplayAmount { get; }

        public RewardCardCollectionStars()
        {
        }

        public RewardCardCollectionStars(int amount, CurrencySource currencySource)
        {
        }
    }
}