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
    public class AnalyticsPlayerDecorationRewardGained : AnalyticsPlayerRewardGained
    {
        [JsonProperty("decoration_id")]
        [Description("ID of the decoration received")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string DecorationId;
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Number of decorations received")]
        [JsonProperty("amount")]
        public int Amount;
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Level of decoration received")]
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