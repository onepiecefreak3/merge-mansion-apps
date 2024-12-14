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
    public class AnalyticsDailyScoopProgress : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        [Description("Event ID")]
        [JsonProperty("daily_challenge_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("week instance")]
        [JsonProperty("daily_challenge_week_id")]
        public string WeekId { get; set; }

        [JsonProperty("daily_challenge_day")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Day instance")]
        public string DayId { get; set; }

        [JsonProperty("daily_challenge_objective_type")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Task objective type")]
        public StatsObjectiveType ObjectiveType { get; set; }

        [MetaMember(21, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("daily_challenge_objective_order")]
        public Dictionary<string, int> ObjectiveOrder { get; set; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(22, (MetaMemberFlags)0)]
        [JsonProperty("daily_challenge_objective_category")]
        public Dictionary<string, string> ObjectiveCategory { get; set; }

        [JsonProperty("daily_challenge_objective_name")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Task objective parameter/name")]
        public string ObjectiveParameter { get; set; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("daily_challenge_objective_requirement")]
        [MetaMember(23, (MetaMemberFlags)0)]
        public Dictionary<string, int> ObjectiveRequirement { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Task progress amount")]
        [JsonProperty("daily_challenge_objective_requirement_amount")]
        public int ObjectiveProgressAmount { get; set; }

        [JsonProperty("daily_challenge_objective_requirement_saldo")]
        [MetaMember(24, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<string, int> ObjectiveProgressSaldo { get; set; }

        [JsonProperty("daily_challenge_token_amount")]
        [MetaMember(25, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<string, int> EventPointReceived { get; set; }

        [JsonProperty("daily_challenge_token_saldo")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("Total amount of event points after receiving reward")]
        public int EventPointSaldo { get; set; }

        [JsonProperty("previous_daily_challenge_weekly_milestone")]
        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("The ID of the previous milestone")]
        public string PreviousMileStoneId { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        [Description("The ID of the daily reward")]
        [JsonProperty("daily_challenge_total_reward")]
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

        [Description("The ID of the last milestone")]
        [JsonProperty("max_daily_challenge_weekly_milestone")]
        [MetaMember(18, (MetaMemberFlags)0)]
        public int LastMileStoneIndex { get; set; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("secondary_reward_recieved")]
        [MetaMember(26, (MetaMemberFlags)0)]
        public Dictionary<string, string> SecondaryReward { get; set; }

        public AnalyticsDailyScoopProgress(string eventId, string weekId, string dayId, StatsObjectiveType objectiveType, int objectiveOrder, string objectiveCategory, string objectiveParameter, int objectiveRequirement, int objectiveProgressAmount, int objectiveProgressSaldo, int eventPointReceived, int eventPointSaldo, string previousMileStoneId, int nextMileStoneIndex, int lastMileStoneIndex, string dailyRewardId, string secondaryReward)
        {
        }

        private static string Locked;
        private static string Unlocked;
        [JsonProperty("daily_challenge_event_state")]
        [MetaMember(20, (MetaMemberFlags)0)]
        [Description("The state of the daily challenge event")]
        public string EventState { get; set; }

        public AnalyticsDailyScoopProgress(string eventId, string weekId, string dayId, StatsObjectiveType objectiveType, int objectiveProgressAmount, int eventPointSaldo, string previousMileStoneId, int nextMileStoneIndex, int lastMileStoneIndex, string dailyRewardId, bool eventState, List<DailyScoopProgressAnalyticsData> objectivesData)
        {
        }
    }
}