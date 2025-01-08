using Metaplay.Core.Analytics;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;
using GameLogic;
using Code.GameLogic.GameEvents;
using GameLogic.Player;

namespace Analytics
{
    [AnalyticsEvent(207, "Player received a wild card reward", 1, null, true, true, false)]
    public class AnalyticsPlayerWildCardRewardGained : AnalyticsPlayerRewardGained
    {
        [JsonProperty("card_pack_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("ID of the wild card received")]
        public string WildCardId;
        [JsonProperty("reward_type")]
        [Description("Type of the reward received")]
        public sealed override string RewardType { get; }
        public override string EventDescription { get; }

        public AnalyticsPlayerWildCardRewardGained(CurrencySource rewardSource, string context, string eventOfferSetId, EventLevelId eventLevelId, AnalyticsContext analyticsContext)
        {
        }

        public AnalyticsPlayerWildCardRewardGained()
        {
        }
    }
}