using Metaplay.Core.Model;
using System;
using Newtonsoft.Json;
using System.ComponentModel;
using Code.GameLogic.GameEvents;
using GameLogic;
using GameLogic.Player;

namespace Analytics
{
    [MetaReservedMembers(200, 299)]
    [MetaSerializable]
    public abstract class AnalyticsPlayerRewardGained : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }
        public abstract string RewardType { get; }

        [JsonProperty("reward_source")]
        [Description("Source of the reward received")]
        [MetaMember(200, (MetaMemberFlags)0)]
        public CurrencySource RewardSource { get; set; }

        [Description("Context")]
        [MetaMember(201, (MetaMemberFlags)0)]
        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("offer_set_id")]
        [MetaMember(202, (MetaMemberFlags)0)]
        [Description("Context")]
        public string EventOfferSetId { get; set; }

        [JsonProperty("event_level_id")]
        [Description("Level id")]
        [MetaMember(203, (MetaMemberFlags)0)]
        public EventLevelId EventLevelId { get; set; }

        protected AnalyticsPlayerRewardGained()
        {
        }

        protected AnalyticsPlayerRewardGained(CurrencySource rewardSource, string context, string eventOfferSetId, EventLevelId eventLevelId)
        {
        }

        [JsonProperty("offer_id", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(204, (MetaMemberFlags)0)]
        [Description("Offer id")]
        public string OfferId { get; set; }

        [MetaMember(205, (MetaMemberFlags)0)]
        [JsonProperty("transaction_id", NullValueHandling = (NullValueHandling)1)]
        [Description("Transaction id")]
        public string TransactionId { get; set; }

        protected AnalyticsPlayerRewardGained(CurrencySource rewardSource, string context, string eventOfferSetId, EventLevelId eventLevelId, AnalyticsContext analyticsContext)
        {
        }
    }
}