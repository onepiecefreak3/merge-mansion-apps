using Metaplay.Core.Model;
using System;
using Newtonsoft.Json;
using System.ComponentModel;
using Code.GameLogic.GameEvents;
using GameLogic;
using GameLogic.Player;

namespace Analytics
{
    [MetaSerializable]
    [MetaReservedMembers(200, 299)]
    public abstract class AnalyticsPlayerRewardGained : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }
        public abstract string RewardType { get; }

        [MetaMember(200, (MetaMemberFlags)0)]
        [JsonProperty("reward_source")]
        [Description("Source of the reward received")]
        public CurrencySource RewardSource { get; set; }

        [Description("Context")]
        [MetaMember(201, (MetaMemberFlags)0)]
        [JsonProperty("context")]
        public string Context { get; set; }

        [Description("Context")]
        [MetaMember(202, (MetaMemberFlags)0)]
        [JsonProperty("offer_set_id")]
        public string EventOfferSetId { get; set; }

        [Description("Level id")]
        [JsonProperty("event_level_id")]
        [MetaMember(203, (MetaMemberFlags)0)]
        public EventLevelId EventLevelId { get; set; }

        protected AnalyticsPlayerRewardGained()
        {
        }

        protected AnalyticsPlayerRewardGained(CurrencySource rewardSource, string context, string eventOfferSetId, EventLevelId eventLevelId)
        {
        }

        [MetaMember(204, (MetaMemberFlags)0)]
        [JsonProperty("offer_id", NullValueHandling = (NullValueHandling)1)]
        [Description("Offer id")]
        public string OfferId { get; set; }

        [JsonProperty("transaction_id", NullValueHandling = (NullValueHandling)1)]
        [Description("Transaction id")]
        [MetaMember(205, (MetaMemberFlags)0)]
        public string TransactionId { get; set; }

        protected AnalyticsPlayerRewardGained(CurrencySource rewardSource, string context, string eventOfferSetId, EventLevelId eventLevelId, AnalyticsContext analyticsContext)
        {
        }
    }
}