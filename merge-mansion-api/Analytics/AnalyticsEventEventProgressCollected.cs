using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using Merge;
using System;

namespace Analytics
{
    [AnalyticsEvent(106, "Event progress collected", 1, null, false, true, false)]
    public class AnalyticsEventEventProgressCollected : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Merge board of the event where progress was made")]
        [JsonProperty("event_id")]
        public MergeBoardId BoardId { get; set; }

        [Description("How many points player made")]
        [JsonProperty("event_progress_gained")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public int EventProgressGained { get; set; }

        [JsonProperty("event_progress_saldo")]
        [Description("Current amount of points that player has")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public int EventProgressSaldo { get; set; }

        [Description("How many times event was started")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("event_start_count")]
        public int EventStartCount { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventEventProgressCollected()
        {
        }

        public AnalyticsEventEventProgressCollected(MergeBoardId boardId, int eventProgressGained, int eventProgressSaldo, int eventStartCount)
        {
        }
    }
}