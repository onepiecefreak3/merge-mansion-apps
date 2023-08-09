using Metaplay.Core.Analytics;
using System.ComponentModel;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System;
using Code.GameLogic.GameEvents;
using GameLogic;

namespace Analytics
{
    [AnalyticsEvent(131, "Player received item reward", 1, null, false, true, false)]
    public class AnalyticsPlayerItemRewardGained : AnalyticsPlayerRewardGained
    {
        [Description("ID of the received item")]
        [JsonProperty("item_name")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ItemName;
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Amount of the received items")]
        [JsonProperty("amount")]
        public int Amount;
        [Description("Type of the reward received")]
        [JsonProperty("reward_type")]
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
    }
}