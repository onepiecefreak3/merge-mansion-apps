using Metaplay.Core.Analytics;
using System;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.Model;
using GameLogic.StatsTracking;

namespace Analytics
{
    [AnalyticsEvent(198, "Daily Scoop Task Progress", 1, null, true, true, false)]
    public class AnalyticsDailyScoopProgress : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        [JsonProperty("daily_challenge_id")]
        [Description("Event ID")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string EventId { get; set; }

        [Description("week instance")]
        [JsonProperty("daily_challenge_week_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string WeekId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Day instance")]
        [JsonProperty("daily_challenge_day")]
        public string DayId { get; set; }

        [JsonProperty("daily_challenge_objective_type")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Task objective type")]
        public StatsObjectiveType ObjectiveType { get; set; }

        [Description("task objective order")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_objective_order")]
        public int ObjectiveOrder { get; set; }

        [JsonProperty("daily_challenge_objective_category")]
        [Description("Task objective category, standard or special")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public string ObjectiveCategory { get; set; }

        [Description("Task objective parameter/name")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_objective_name")]
        public string ObjectiveParameter { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Objective requirement for completion")]
        [JsonProperty("daily_challenge_objective_requirement")]
        public int ObjectiveRequirement { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Task progress amount")]
        [JsonProperty("daily_challenge_objective_requirement_amount")]
        public int ObjectiveProgressAmount { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Total amount of task progress")]
        [JsonProperty("daily_challenge_objective_requirement_saldo")]
        public int ObjectiveProgressSaldo { get; set; }

        [Description("Amount of event points recieved from the task")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_token_amount")]
        public int EventPointReceived { get; set; }

        [JsonProperty("daily_challenge_token_saldo")]
        [Description("Total amount of event points after receiving reward")]
        [MetaMember(12, (MetaMemberFlags)0)]
        public int EventPointSaldo { get; set; }

        [JsonProperty("previous_daily_challenge_weekly_milestone")]
        [Description("The ID of the previous milestone")]
        [MetaMember(13, (MetaMemberFlags)0)]
        public string PreviousMileStoneId { get; set; }

        [Description("The ID of the next milestone")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [JsonProperty("current_daily_challenge_weekly_milestone")]
        public string NextMileStoneId { get; set; }

        [JsonProperty("max_daily_challenge_weekly_milestone")]
        [Description("The ID of the last milestone")]
        [MetaMember(15, (MetaMemberFlags)0)]
        public string LastMileStoneId { get; set; }

        [Description("The ID of the daily reward")]
        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_total_reward")]
        public string DailyRewardId { get; set; }

        public AnalyticsDailyScoopProgress()
        {
        }

        public AnalyticsDailyScoopProgress(string eventId, string weekId, string dayId, StatsObjectiveType objectiveType, int objectiveOrder, string objectiveCategory, string objectiveParameter, int objectiveRequirement, int objectiveProgressAmount, int objectiveProgressSaldo, int eventPointReceived, int eventPointSaldo, string previousMileStoneId, string nextMileStoneId, string lastMileStoneId, string dailyRewardId)
        {
        }
    }
}