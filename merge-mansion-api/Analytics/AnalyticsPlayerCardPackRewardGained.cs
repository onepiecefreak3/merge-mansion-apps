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
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("card_pack_id")]
        [Description("ID of the card pack received")]
        public string CardPackId;
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("amount")]
        [Description("Number of card packs received")]
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