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

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("event_id")]
        [Description("Id of the event")]
        public string EventId { get; set; }

        [JsonProperty("day_id")]
        [Description("The ID of the event day")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string DayId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("active_tasks")]
        [Description("A dictionary of the active tasks for the day")]
        public string ActiveTasks { get; set; }

        public AnalyticsDailyScoopDayStartedEvent()
        {
        }

        public AnalyticsDailyScoopDayStartedEvent(string eventId, string dayId, string activeTasks)
        {
        }
    }
}