using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System;
using Metaplay.Core.Model;
using System.ComponentModel;

namespace Analytics
{
    [AnalyticsEvent(167, "Daily task first impression", 1, null, false, true, false)]
    public class AnalyticsEventDailyTaskFirstImpression : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty(PropertyName = "state", DefaultValueHandling = (DefaultValueHandling)0)]
        public string State { get; }

        [JsonProperty("task_index")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Index of the task")]
        public int TaskIndex { get; set; }

        [Description("Id of the required item")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("required_item")]
        public string RequiredItem { get; set; }

        [Description("How many items were required")]
        [JsonProperty("required_item_count")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public int RequiredItemCount { get; set; }

        [JsonProperty("reward_item")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("The received reward item id")]
        public string RewardItem { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("How many reward items were received")]
        [JsonProperty("reward_item_count")]
        public int RewardItemCount { get; set; }

        [JsonProperty("local_datetime")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Player's local date and time")]
        public string LocalDateTime { get; set; }

        [JsonProperty("task_id")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Task ConfigKey")]
        public string TaskId { get; set; }

        [Description("Daily Tasks Set Id")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("daily_tasks_set_id")]
        public string DailyTasksSetId { get; set; }

        [JsonProperty("daily_tasks_final_rewards_id")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Daily Tasks Final Rewards Id")]
        public string DailyTasksFinalRewardsId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventDailyTaskFirstImpression()
        {
        }

        public AnalyticsEventDailyTaskFirstImpression(string taskId, int taskIndex, string requiredItem, int requiredItemCount, string rewardItem, int rewardItemCount, string localDateTime, string dailyTasksSetId, string dailyTasksFinalRewardsId)
        {
        }
    }
}