using Metaplay.Core.Analytics;
using System.ComponentModel;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System;
using Code.GameLogic.GameEvents;
using GameLogic;
using GameLogic.Player.Items;
using GameLogic.Player;

namespace Analytics
{
    [AnalyticsEvent(131, "Player received item reward", 1, null, false, true, false)]
    public class AnalyticsPlayerItemRewardGained : AnalyticsPlayerRewardGained
    {
        [JsonProperty("item_name")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("ID of the received item")]
        public string ItemName;
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("amount")]
        [Description("Amount of the received items")]
        public int Amount;
        [JsonProperty("reward_type")]
        [Description("Type of the reward received")]
        public sealed override string RewardType { get; }
        public override string EventDescription { get; }

        public AnalyticsPlayerItemRewardGained(CurrencySource rewardSource, string context, string eventOfferSetId, EventLevelId eventLeveLId)
        {
        }

        public AnalyticsPlayerItemRewardGained(string itemType, int amount, CurrencySource rewardSource, string context, string eventOfferSetId, EventLevelId eventLeveLId)
        {
        }

        public AnalyticsPlayerItemRewardGained()
        {
        }

        [JsonProperty("duration_in_minutes", DefaultValueHandling = (DefaultValueHandling)1)]
        [Description("Duration in minutes for items with durations")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public double Duration;
        public AnalyticsPlayerItemRewardGained(ItemDefinition itemDefinition, OverrideItemFeatures overrideItemFeatures, int amount, CurrencySource rewardSource, string context, string eventOfferSetId, EventLevelId eventLeveLId)
        {
        }

        public AnalyticsPlayerItemRewardGained(ItemDefinition itemDefinition, OverrideItemFeatures overrideItemFeatures, int amount, CurrencySource rewardSource, string context, AnalyticsContext analyticsContext, string eventOfferSetId, EventLevelId eventLeveLId)
        {
        }
    }
}