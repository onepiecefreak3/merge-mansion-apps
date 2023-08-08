using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using Merge;
using System;

namespace Analytics
{
    [AnalyticsEvent(111, "Event rewards collected", 1, null, false, true, false)]
    public class AnalyticsEventEventRewardsCollected : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Id of the board that corresponds to the event")]
        [JsonProperty("event_id")]
        public MergeBoardId BoardId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("event_level")]
        [Description("Level player reached in the event")]
        public int EventLevel { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventEventRewardsCollected()
        {
        }

        public AnalyticsEventEventRewardsCollected(MergeBoardId boardId, int eventLevel)
        {
        }
    }
}