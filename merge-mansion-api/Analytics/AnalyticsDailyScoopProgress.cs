using Metaplay.Core.Analytics;
using System;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.Model;
using GameLogic.StatsTracking;
using System.Collections.Generic;

namespace Analytics
{
    [AnalyticsEvent(198, "Daily Scoop Task Progress", 1, null, true, true, false)]
    [MetaBlockedMembers(new int[] { 5, 6, 8, 10, 11, 14, 15, 19 })]
    [AnalyticsEventKeywords(new string[] { "daily" })]
    public class AnalyticsDailyScoopProgress : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_id")]
        [Description("Event ID")]
        public string EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("week instance")]
        [JsonProperty("daily_challenge_week_id")]
        public string WeekId { get; set; }

        [JsonProperty("daily_challenge_day")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Day instance")]
        public string DayId { get; set; }

        [Description("Task objective type")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_objective_type")]
        public StatsObjectiveType ObjectiveType { get; set; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("daily_challenge_objective_order")]
        [MetaMember(21, (MetaMemberFlags)0)]
        public Dictionary<string, int> ObjectiveOrder { get; set; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(22, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_objective_category")]
        public Dictionary<string, string> ObjectiveCategory { get; set; }

        [JsonProperty("daily_challenge_objective_name")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Task objective parameter/name")]
        public string ObjectiveParameter { get; set; }

        [JsonProperty("daily_challenge_objective_requirement")]
        [MetaMember(23, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<string, int> ObjectiveRequirement { get; set; }

        [Description("Task progress amount")]
        [JsonProperty("daily_challenge_objective_requirement_amount")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public int ObjectiveProgressAmount { get; set; }

        [JsonProperty("daily_challenge_objective_requirement_saldo")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(24, (MetaMemberFlags)0)]
        public Dictionary<string, int> ObjectiveProgressSaldo { get; set; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(25, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_token_amount")]
        public Dictionary<string, int> EventPointReceived { get; set; }

        [JsonProperty("daily_challenge_token_saldo")]
        [Description("Total amount of event points after receiving reward")]
        [MetaMember(12, (MetaMemberFlags)0)]
        public int EventPointSaldo { get; set; }

        [Description("The ID of the previous milestone")]
        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("previous_daily_challenge_weekly_milestone")]
        public string PreviousMileStoneId { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_total_reward")]
        [Description("The ID of the daily reward")]
        public string DailyRewardId { get; set; }

        public AnalyticsDailyScoopProgress()
        {
        }

        public AnalyticsDailyScoopProgress(string eventId, string weekId, string dayId, StatsObjectiveType objectiveType, int objectiveOrder, string objectiveCategory, string objectiveParameter, int objectiveRequirement, int objectiveProgressAmount, int objectiveProgressSaldo, int eventPointReceived, int eventPointSaldo, string previousMileStoneId, string nextMileStoneId, string lastMileStoneId, string dailyRewardId)
        {
        }

        [JsonProperty("current_daily_challenge_weekly_milestone")]
        [MetaMember(17, (MetaMemberFlags)0)]
        [Description("The ID of the next milestone")]
        public int NextMileStoneIndex { get; set; }

        [JsonProperty("max_daily_challenge_weekly_milestone")]
        [Description("The ID of the last milestone")]
        [MetaMember(18, (MetaMemberFlags)0)]
        public int LastMileStoneIndex { get; set; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(26, (MetaMemberFlags)0)]
        [JsonProperty("secondary_reward_recieved")]
        public Dictionary<string, string> SecondaryReward { get; set; }

        public AnalyticsDailyScoopProgress(string eventId, string weekId, string dayId, StatsObjectiveType objectiveType, int objectiveOrder, string objectiveCategory, string objectiveParameter, int objectiveRequirement, int objectiveProgressAmount, int objectiveProgressSaldo, int eventPointReceived, int eventPointSaldo, string previousMileStoneId, int nextMileStoneIndex, int lastMileStoneIndex, string dailyRewardId, string secondaryReward)
        {
        }

        private static string Locked;
        private static string Unlocked;
        [Description("The state of the daily challenge event")]
        [MetaMember(20, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_event_state")]
        public string EventState { get; set; }

        public AnalyticsDailyScoopProgress(string eventId, string weekId, string dayId, StatsObjectiveType objectiveType, int objectiveProgressAmount, int eventPointSaldo, string previousMileStoneId, int nextMileStoneIndex, int lastMileStoneIndex, string dailyRewardId, bool eventState, List<DailyScoopProgressAnalyticsData> objectivesData)
        {
        }
    }
}