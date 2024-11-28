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

        [JsonProperty("required_item")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Id of the required item")]
        public string RequiredItem { get; set; }

        [Description("How many items were required")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("required_item_count")]
        public int RequiredItemCount { get; set; }

        [Description("The received reward item id")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("reward_item")]
        public string RewardItem { get; set; }

        [Description("How many reward items were received")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("reward_item_count")]
        public int RewardItemCount { get; set; }

        [Description("Player's local date and time")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("local_datetime")]
        public string LocalDateTime { get; set; }

        [Description("Task ConfigKey")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("task_id")]
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

        public AnalyticsEventDailyTaskFirstImpression()
        {
        }

        public AnalyticsEventDailyTaskFirstImpression(string taskId, int taskIndex, string requiredItem, int requiredItemCount, string rewardItem, int rewardItemCount, string localDateTime, string dailyTasksSetId, string dailyTasksFinalRewardsId)
        {
        }

        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("is_purchased_task")]
        [Description("Is Purchased Task")]
        public bool IsPurchasedTask { get; set; }

        public AnalyticsEventDailyTaskFirstImpression(string taskId, int taskIndex, string requiredItem, int requiredItemCount, string rewardItem, int rewardItemCount, string localDateTime, string dailyTasksSetId, string dailyTasksFinalRewardsId, bool isPurchasedTask)
        {
        }

        [Description("Required item level")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [JsonProperty("required_item_level")]
        public int RequiredItemLevel { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("Merge chain total length of the required item")]
        [JsonProperty("required_item_mergechain_total_length")]
        public int RequiredItemMergeChainTotalLength { get; set; }

        [JsonProperty("required_item_mergechain_unlocked_length")]
        [Description("Merge chain unlocked length of the required item")]
        [MetaMember(13, (MetaMemberFlags)0)]
        public int RequiredItemMergeChainUnlockedLength { get; set; }

        [JsonProperty("reward_item_level")]
        [Description("Reward item level")]
        [MetaMember(14, (MetaMemberFlags)0)]
        public int RewardItemLevel { get; set; }

        [JsonProperty("reward_item_mergechain_total_length")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [Description("Merge chain total length of the reward item")]
        public int RewardItemMergeChainTotalLength { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("reward_item_mergechain_unlocked_length")]
        [Description("Merge chain unlocked length of the reward item")]
        public int RewardItemMergeChainUnlockedLength { get; set; }

        public AnalyticsEventDailyTaskFirstImpression(string taskId, int taskIndex, string requiredItem, int requiredItemCount, string rewardItem, int rewardItemCount, string localDateTime, string dailyTasksSetId, string dailyTasksFinalRewardsId, bool isPurchasedTask, int requiredItemLevel, int requiredItemMergeChainTotalLength, int requiredItemMergeChainUnlockedLength, int rewardItemLevel, int rewardItemMergeChainTotalLength, int rewardItemMergeChainUnlockedLength)
        {
        }
    }
}