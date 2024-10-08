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
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("ID of the event")]
        [JsonProperty("event_id")]
        public string EventId;
        [JsonProperty("claimed_level")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Claimed level")]
        public int ClaimedLevel;
        [JsonProperty("auto_claim")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Was the level claimed automatically?")]
        public bool AutoClaim;
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("event_level_id")]
        [Description("Event level id")]
        public EventLevelId EventLevelId;
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        public AnalyticsGameEventLevelUp()
        {
        }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("The amount of ResourceItems used until now in the whole event (SideBoardEvent only)")]
        [JsonProperty("resource_item_used", NullValueHandling = (NullValueHandling)1)]
        public int? ResourceItemUsed;
    }
}