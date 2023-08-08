using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using System;
using Code.GameLogic.GameEvents;

namespace Analytics
{
    [AnalyticsEvent(129, "Player received a decoration reward", 1, null, true, true, false)]
    public class AnalyticsPlayerDecorationRewardGained : AnalyticsPlayerRewardGained
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("ID of the decoration received")]
        [JsonProperty("decoration_id")]
        public string DecorationId;
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("amount")]
        [Description("Number of decorations received")]
        public int Amount;
        [JsonProperty("level", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Level of decoration received")]
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
    }
}