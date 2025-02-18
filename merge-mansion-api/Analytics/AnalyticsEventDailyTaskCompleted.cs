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

        [Description("Index of the task that was completed")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("task_index")]
        public int TaskIndex { get; set; }

        [JsonProperty("required_item")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Id of the required item")]
        public string RequiredItem { get; set; }

        [JsonProperty("required_item_count")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("How many items were required")]
        public int RequiredItemCount { get; set; }

        [Description("The received reward item id")]
        [JsonProperty("reward_item")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public string RewardItem { get; set; }

        [JsonProperty("reward_item_count")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("How many reward items were received")]
        public int RewardItemCount { get; set; }

        [JsonProperty("local_datetime")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Player's local date and time")]
        public string LocalDateTime { get; set; }

        [Description("Task ConfigKey")]
        [JsonProperty("task_id")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public string TaskId { get; set; }

        [Description("Daily Tasks Set Id")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("daily_tasks_set_id")]
        public string DailyTasksSetId { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("daily_tasks_final_rewards_id")]
        [Description("Daily Tasks Final Rewards Id")]
        public string DailyTasksFinalRewardsId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventDailyTaskCompleted()
        {
        }

        public AnalyticsEventDailyTaskCompleted(string taskId, int taskIndex, string requiredItem, int requiredItemCount, string rewardItem, int rewardItemCount, string localDateTime, string dailyTasksSetId, string dailyTasksFinalRewardsId)
        {
        }

        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("is_purchased_task")]
        [Description("Is Purchased Task")]
        public bool IsPurchasedTask { get; set; }

        public AnalyticsEventDailyTaskCompleted(string taskId, int taskIndex, string requiredItem, int requiredItemCount, string rewardItem, int rewardItemCount, string localDateTime, string dailyTasksSetId, string dailyTasksFinalRewardsId, bool isPurchasedTask)
        {
        }

        [JsonProperty("required_item_level")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [Description("Required item level")]
        public int RequiredItemLevel { get; set; }

        [Description("Merge chain total length of the required item")]
        [JsonProperty("required_item_mergechain_total_length")]
        [MetaMember(12, (MetaMemberFlags)0)]
        public int RequiredItemMergeChainTotalLength { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Merge chain unlocked length of the required item")]
        [JsonProperty("required_item_mergechain_unlocked_length")]
        public int RequiredItemMergeChainUnlockedLength { get; set; }

        [JsonProperty("reward_item_level")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [Description("Reward item level")]
        public int RewardItemLevel { get; set; }

        [JsonProperty("reward_item_mergechain_total_length")]
        [Description("Merge chain total length of the reward item")]
        [MetaMember(15, (MetaMemberFlags)0)]
        public int RewardItemMergeChainTotalLength { get; set; }

        [JsonProperty("reward_item_mergechain_unlocked_length")]
        [Description("Merge chain unlocked length of the reward item")]
        [MetaMember(16, (MetaMemberFlags)0)]
        public int RewardItemMergeChainUnlockedLength { get; set; }

        public AnalyticsEventDailyTaskCompleted(string taskId, int taskIndex, string requiredItem, int requiredItemCount, string rewardItem, int rewardItemCount, string localDateTime, string dailyTasksSetId, string dailyTasksFinalRewardsId, bool isPurchasedTask, int requiredItemLevel, int requiredItemMergeChainTotalLength, int requiredItemMergeChainUnlockedLength, int rewardItemLevel, int rewardItemMergeChainTotalLength, int rewardItemMergeChainUnlockedLength)
        {
        }
    }
}