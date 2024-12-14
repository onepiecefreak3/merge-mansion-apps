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

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("task_index")]
        [Description("Index of the task that was completed")]
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
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("reward_item")]
        public string RewardItem { get; set; }

        [Description("How many reward items were received")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("reward_item_count")]
        public int RewardItemCount { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("local_datetime")]
        [Description("Player's local date and time")]
        public string LocalDateTime { get; set; }

        [JsonProperty("task_id")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Task ConfigKey")]
        public string TaskId { get; set; }

        [JsonProperty("daily_tasks_set_id")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Daily Tasks Set Id")]
        public string DailyTasksSetId { get; set; }

        [Description("Daily Tasks Final Rewards Id")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("daily_tasks_final_rewards_id")]
        public string DailyTasksFinalRewardsId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventDailyTaskCompleted()
        {
        }

        public AnalyticsEventDailyTaskCompleted(string taskId, int taskIndex, string requiredItem, int requiredItemCount, string rewardItem, int rewardItemCount, string localDateTime, string dailyTasksSetId, string dailyTasksFinalRewardsId)
        {
        }

        [Description("Is Purchased Task")]
        [JsonProperty("is_purchased_task")]
        [MetaMember(10, (MetaMemberFlags)0)]
        public bool IsPurchasedTask { get; set; }

        public AnalyticsEventDailyTaskCompleted(string taskId, int taskIndex, string requiredItem, int requiredItemCount, string rewardItem, int rewardItemCount, string localDateTime, string dailyTasksSetId, string dailyTasksFinalRewardsId, bool isPurchasedTask)
        {
        }

        [Description("Required item level")]
        [JsonProperty("required_item_level")]
        [MetaMember(11, (MetaMemberFlags)0)]
        public int RequiredItemLevel { get; set; }

        [JsonProperty("required_item_mergechain_total_length")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("Merge chain total length of the required item")]
        public int RequiredItemMergeChainTotalLength { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Merge chain unlocked length of the required item")]
        [JsonProperty("required_item_mergechain_unlocked_length")]
        public int RequiredItemMergeChainUnlockedLength { get; set; }

        [Description("Reward item level")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [JsonProperty("reward_item_level")]
        public int RewardItemLevel { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        [Description("Merge chain total length of the reward item")]
        [JsonProperty("reward_item_mergechain_total_length")]
        public int RewardItemMergeChainTotalLength { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("reward_item_mergechain_unlocked_length")]
        [Description("Merge chain unlocked length of the reward item")]
        public int RewardItemMergeChainUnlockedLength { get; set; }

        public AnalyticsEventDailyTaskCompleted(string taskId, int taskIndex, string requiredItem, int requiredItemCount, string rewardItem, int rewardItemCount, string localDateTime, string dailyTasksSetId, string dailyTasksFinalRewardsId, bool isPurchasedTask, int requiredItemLevel, int requiredItemMergeChainTotalLength, int requiredItemMergeChainUnlockedLength, int rewardItemLevel, int rewardItemMergeChainTotalLength, int rewardItemMergeChainUnlockedLength)
        {
        }
    }
}