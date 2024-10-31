using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using System;
using Code.GameLogic.GameEvents;
using GameLogic;
using GameLogic.Player;

namespace Analytics
{
    [AnalyticsEvent(130, "Player received event points as a reward", 1, null, true, true, false)]
    public class AnalyticsPlayerEventPointsRewardGained : AnalyticsPlayerRewardGained
    {
        [JsonProperty("event_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Event ID")]
        public string EventId;
        [Description("Amount of points received")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("amount")]
        public int Amount;
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("saldo")]
        [Description("Total event points")]
        public long TotalAfterAdd;
        [JsonProperty("reward_type")]
        [Description("Type of the reward received")]
        public sealed override string RewardType { get; }
        public override string EventDescription { get; }

        public AnalyticsPlayerEventPointsRewardGained(CurrencySource rewardSource, EventLevelId eventLevelId)
        {
        }

        public AnalyticsPlayerEventPointsRewardGained()
        {
        }

        public AnalyticsPlayerEventPointsRewardGained(CurrencySource rewardSource, EventLevelId eventLevelId, AnalyticsContext analyticsContext)
        {
        }
    }
}