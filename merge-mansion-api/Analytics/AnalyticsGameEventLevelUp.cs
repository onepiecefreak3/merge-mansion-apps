using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using System;
using Code.GameLogic.GameEvents;

namespace Analytics
{
    [AnalyticsEvent(125, "Event level was reached and claimed", 1, null, false, true, false)]
    public class AnalyticsGameEventLevelUp : AnalyticsServersideEventBase
    {
        [JsonProperty("event_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("ID of the event")]
        public string EventId;
        [JsonProperty("claimed_level")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Claimed level")]
        public int ClaimedLevel;
        [Description("Was the level claimed automatically?")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("auto_claim")]
        public bool AutoClaim;
        [Description("Event level id")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("event_level_id")]
        public EventLevelId EventLevelId;
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        public AnalyticsGameEventLevelUp()
        {
        }

        [JsonProperty("resource_item_used", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("The amount of ResourceItems used until now in the whole event (SideBoardEvent only)")]
        public int? ResourceItemUsed;
    }
}