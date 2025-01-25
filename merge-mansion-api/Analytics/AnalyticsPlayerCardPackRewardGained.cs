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
    [AnalyticsEventKeywords(new string[] { "event" })]
    [AnalyticsEvent(206, "Player received a card pack reward", 1, null, true, true, false)]
    public class AnalyticsPlayerCardPackRewardGained : AnalyticsPlayerRewardGained
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("ID of the card pack received")]
        [JsonProperty("item_name")]
        public string CardPackId;
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Number of card packs received")]
        [JsonProperty("amount")]
        public int Amount;
        [Description("Type of the reward received")]
        [JsonProperty("reward_type")]
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