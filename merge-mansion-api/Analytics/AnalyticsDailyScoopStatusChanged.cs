using Metaplay.Core.Analytics;
using System;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Analytics
{
    [AnalyticsEvent(199, "Daily Scoop status changed", 1, null, false, true, false)]
    [AnalyticsEventKeywords(new string[] { "daily" })]
    public class AnalyticsDailyScoopStatusChanged : AnalyticsServersideEventBase
    {
        public override string EventDescription { get; }
        public override AnalyticsEventType EventType { get; }

        [Description("Event ID")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_id")]
        public string EventId { get; set; }

        [Description("week ID")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_week_id")]
        public string WeekId { get; set; }

        [Description("Day ID")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_day")]
        public string DayId { get; set; }

        [Description("Status of the task, unlocked/completed")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_status")]
        public TaskStatus Status { get; set; }

        [Description("The type of the task, Standard/Special")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_objective_category")]
        public TaskType Type { get; set; }

        [Description("The amount of event tokens the task rewards")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_token_amount")]
        public int TokenAmount { get; set; }

        public AnalyticsDailyScoopStatusChanged()
        {
        }

        public AnalyticsDailyScoopStatusChanged(string eventId, string weekId, string dayId, TaskStatus status, TaskType type, int tokenAmount)
        {
        }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_task_id")]
        [Description("Task ID")]
        public string TaskId { get; set; }

        public AnalyticsDailyScoopStatusChanged(string eventId, string weekId, string dayId, TaskStatus status, TaskType type, int tokenAmount, string taskId)
        {
        }
    }
}