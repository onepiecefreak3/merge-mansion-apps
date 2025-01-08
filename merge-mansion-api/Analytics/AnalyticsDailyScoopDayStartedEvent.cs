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

        [Description("Id of the event")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [Description("The ID of the event day")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("day_id")]
        public string DayId { get; set; }

        [Description("A dictionary of the active tasks for the day")]
        [JsonProperty("active_tasks")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public string ActiveTasks { get; set; }

        public AnalyticsDailyScoopDayStartedEvent()
        {
        }

        public AnalyticsDailyScoopDayStartedEvent(string eventId, string dayId, string activeTasks)
        {
        }
    }
}