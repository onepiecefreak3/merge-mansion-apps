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
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("ID of the decoration received")]
        [JsonProperty("decoration_id")]
        public string DecorationId;
        [Description("Number of decorations received")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("amount")]
        public int Amount;
        [Description("Level of decoration received")]
        [JsonProperty("level", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(3, (MetaMemberFlags)0)]
        public int? Level;
        [JsonProperty("reward_type")]
        [Description("Type of the reward received")]
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