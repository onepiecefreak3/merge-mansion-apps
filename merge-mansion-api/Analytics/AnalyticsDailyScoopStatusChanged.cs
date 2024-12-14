using Metaplay.Core.Analytics;
using System;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Analytics
{
    [AnalyticsEvent(199, "Daily Scoop status changed", 1, null, false, true, false)]
    public class AnalyticsDailyScoopStatusChanged : AnalyticsServersideEventBase
    {
        public override string EventDescription { get; }
        public override AnalyticsEventType EventType { get; }

        [Description("Event ID")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_id")]
        public string EventId { get; set; }

        [JsonProperty("daily_challenge_week_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("week ID")]
        public string WeekId { get; set; }

        [Description("Day ID")]
        [JsonProperty("daily_challenge_day")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public string DayId { get; set; }

        [Description("Status of the task, unlocked/completed")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_status")]
        public TaskStatus Status { get; set; }

        [JsonProperty("daily_challenge_objective_category")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("The type of the task, Standard/Special")]
        public TaskType Type { get; set; }

        [JsonProperty("daily_challenge_token_amount")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("The amount of event tokens the task rewards")]
        public int TokenAmount { get; set; }

        public AnalyticsDailyScoopStatusChanged()
        {
        }

        public AnalyticsDailyScoopStatusChanged(string eventId, string weekId, string dayId, TaskStatus status, TaskType type, int tokenAmount)
        {
        }

        [JsonProperty("daily_challenge_task_id")]
        [Description("Task ID")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public string TaskId { get; set; }

        public AnalyticsDailyScoopStatusChanged(string eventId, string weekId, string dayId, TaskStatus status, TaskType type, int tokenAmount, string taskId)
        {
        }
    }
}