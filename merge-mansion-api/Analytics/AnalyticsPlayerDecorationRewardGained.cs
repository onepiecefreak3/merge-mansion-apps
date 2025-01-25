using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using System;
using Code.GameLogic.GameEvents;
using GameLogic;
using GameLogic.Player;

namespace Analytics
{
    [AnalyticsEvent(129, "Player received a decoration reward", 1, null, true, true, false)]
    [AnalyticsEventKeywords(new string[] { "event" })]
    public class AnalyticsPlayerDecorationRewardGained : AnalyticsPlayerRewardGained
    {
        [JsonProperty("decoration_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("ID of the decoration received")]
        public string DecorationId;
        [JsonProperty("amount")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Number of decorations received")]
        public int Amount;
        [Description("Level of decoration received")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("level", NullValueHandling = (NullValueHandling)1)]
        public int? Level;
        [Description("Type of the reward received")]
        [JsonProperty("reward_type")]
        public sealed override string RewardType { get; }
        public override string EventDescription { get; }

        public AnalyticsPlayerDecorationRewardGained(CurrencySource rewardSource, string context, string eventOfferSetId, EventLevelId eventLevelId)
        {
        }

        public AnalyticsPlayerDecorationRewardGained()
        {
        }

        public AnalyticsPlayerDecorationRewardGained(CurrencySource rewardSource, string context, string eventOfferSetId, EventLevelId eventLevelId, AnalyticsContext analyticsContext)
        {
        }
    }
}