using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using System;
using GameLogic;
using Code.GameLogic.GameEvents;
using GameLogic.Player;

namespace Analytics
{
    [AnalyticsEvent(178, "Player received a pet reward", 1, null, true, true, false)]
    public class AnalyticsPlayerPetRewardGained : AnalyticsPlayerRewardGained
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("pet_id")]
        [Description("ID of the pet received")]
        public string PetId;
        [Description("Number of pets received")]
        [JsonProperty("amount")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Amount;
        [JsonProperty("reward_type")]
        [Description("Type of the reward received")]
        public sealed override string RewardType { get; }
        public override string EventDescription { get; }

        public AnalyticsPlayerPetRewardGained(CurrencySource rewardSource, string context, string eventOfferSetId, EventLevelId eventLevelId)
        {
        }

        public AnalyticsPlayerPetRewardGained()
        {
        }

        public AnalyticsPlayerPetRewardGained(CurrencySource rewardSource, string context, string eventOfferSetId, EventLevelId eventLevelId, AnalyticsContext analyticsContext)
        {
        }
    }
}