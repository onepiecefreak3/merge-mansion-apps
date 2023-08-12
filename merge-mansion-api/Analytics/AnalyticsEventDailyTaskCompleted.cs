using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using Metaplay.Core.Model;

namespace Analytics
{
    [AnalyticsEvent(112, "Daily task completed", 1, null, false, true, false)]
    public class AnalyticsEventDailyTaskCompleted : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty(PropertyName = "state", DefaultValueHandling = (DefaultValueHandling)0)]
        public string State { get; }

        [JsonProperty("task_index")]
        [Description("Index of the task that was completed")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public int TaskIndex { get; set; }

        [Description("Id of the required item")]
        [JsonProperty("required_item")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string RequiredItem { get; set; }

        [Description("How many items were required")]
        [JsonProperty("required_item_count")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public int RequiredItemCount { get; set; }

        [JsonProperty("reward_item")]
        [Description("The received reward item id")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public string RewardItem { get; set; }

        [Description("How many reward items were received")]
        [JsonProperty("reward_item_count")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public int RewardItemCount { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Player's local date and time")]
        [JsonProperty("local_datetime")]
        public string LocalDateTime { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("task_id")]
        [Description("Task ConfigKey")]
        public string TaskId { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Daily Tasks Set Id")]
        [JsonProperty("daily_tasks_set_id")]
        public string DailyTasksSetId { get; set; }

        [JsonProperty("daily_tasks_final_rewards_id")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Daily Tasks Final Rewards Id")]
        public string DailyTasksFinalRewardsId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventDailyTaskCompleted()
        {
        }

        public AnalyticsEventDailyTaskCompleted(string taskId, int taskIndex, string requiredItem, int requiredItemCount, string rewardItem, int rewardItemCount, string localDateTime, string dailyTasksSetId, string dailyTasksFinalRewardsId)
        {
        }

        [Description("Is Purchased Task")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("is_purchased_task")]
        public bool IsPurchasedTask { get; set; }

        public AnalyticsEventDailyTaskCompleted(string taskId, int taskIndex, string requiredItem, int requiredItemCount, string rewardItem, int rewardItemCount, string localDateTime, string dailyTasksSetId, string dailyTasksFinalRewardsId, bool isPurchasedTask)
        {
        }
    }
}