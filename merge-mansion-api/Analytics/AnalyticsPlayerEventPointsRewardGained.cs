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
        [Description("Event ID")]
        [JsonProperty("event_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string EventId;
        [Description("Amount of points received")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("amount")]
        public int Amount;
        [JsonProperty("saldo")]
        [Description("Total event points")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public long TotalAfterAdd;
        [Description("Type of the reward received")]
        [JsonProperty("reward_type")]
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