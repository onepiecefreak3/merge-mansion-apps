using Metaplay.Core.Analytics;
using System;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Analytics
{
    [AnalyticsEvent(200, "Daily Scoop Day Started", 1, null, false, true, false)]
    public class AnalyticsDailyScoopDayStartedEvent : AnalyticsServersideEventBase
    {
        public override string EventDescription { get; }
        public override AnalyticsEventType EventType { get; }

        [JsonProperty("event_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Id of the event")]
        public string EventId { get; set; }

        [JsonProperty("day_id")]
        [Description("The ID of the event day")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string DayId { get; set; }

        [Description("A dictionary of the active tasks for the day")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("active_tasks")]
        public string ActiveTasks { get; set; }

        public AnalyticsDailyScoopDayStartedEvent()
        {
        }

        public AnalyticsDailyScoopDayStartedEvent(string eventId, string dayId, string activeTasks)
        {
        }
    }
}