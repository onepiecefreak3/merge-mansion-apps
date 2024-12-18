using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using GameLogic;
using Code.GameLogic.GameEvents;
using GameLogic.Player;

namespace Analytics
{
    [AnalyticsEvent(206, "Player received a card pack reward", 1, null, true, true, false)]
    public class AnalyticsPlayerCardPackRewardGained : AnalyticsPlayerRewardGained
    {
        [JsonProperty("item_name")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("ID of the card pack received")]
        public string CardPackId;
        [JsonProperty("amount")]
        [Description("Number of card packs received")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Amount;
        [JsonProperty("reward_type")]
        [Description("Type of the reward received")]
        public sealed override string RewardType { get; }
        public override string EventDescription { get; }

        public AnalyticsPlayerCardPackRewardGained(CurrencySource rewardSource, string context, string eventOfferSetId, EventLevelId eventLevelId, AnalyticsContext analyticsContext)
        {
        }

        public AnalyticsPlayerCardPackRewardGained()
        {
        }
    }
}