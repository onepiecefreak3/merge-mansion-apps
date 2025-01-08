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

        [Description("Index of the task")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("task_index")]
        public int TaskIndex { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Id of the required item")]
        [JsonProperty("required_item")]
        public string RequiredItem { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("How many items were required")]
        [JsonProperty("required_item_count")]
        public int RequiredItemCount { get; set; }

        [JsonProperty("reward_item")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("The received reward item id")]
        public string RewardItem { get; set; }

        [JsonProperty("reward_item_count")]
        [Description("How many reward items were received")]
        [MetaMember(5, (MetaMemberFlags)0)]
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

        [Description("Daily Tasks Final Rewards Id")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("daily_tasks_final_rewards_id")]
        public string DailyTasksFinalRewardsId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventDailyTaskFirstImpression()
        {
        }

        public AnalyticsEventDailyTaskFirstImpression(string taskId, int taskIndex, string requiredItem, int requiredItemCount, string rewardItem, int rewardItemCount, string localDateTime, string dailyTasksSetId, string dailyTasksFinalRewardsId)
        {
        }

        [Description("Is Purchased Task")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("is_purchased_task")]
        public bool IsPurchasedTask { get; set; }

        public AnalyticsEventDailyTaskFirstImpression(string taskId, int taskIndex, string requiredItem, int requiredItemCount, string rewardItem, int rewardItemCount, string localDateTime, string dailyTasksSetId, string dailyTasksFinalRewardsId, bool isPurchasedTask)
        {
        }

        [JsonProperty("required_item_level")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [Description("Required item level")]
        public int RequiredItemLevel { get; set; }

        [Description("Merge chain total length of the required item")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("required_item_mergechain_total_length")]
        public int RequiredItemMergeChainTotalLength { get; set; }

        [Description("Merge chain unlocked length of the required item")]
        [JsonProperty("required_item_mergechain_unlocked_length")]
        [MetaMember(13, (MetaMemberFlags)0)]
        public int RequiredItemMergeChainUnlockedLength { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        [Description("Reward item level")]
        [JsonProperty("reward_item_level")]
        public int RewardItemLevel { get; set; }

        [Description("Merge chain total length of the reward item")]
        [JsonProperty("reward_item_mergechain_total_length")]
        [MetaMember(15, (MetaMemberFlags)0)]
        public int RewardItemMergeChainTotalLength { get; set; }

        [Description("Merge chain unlocked length of the reward item")]
        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("reward_item_mergechain_unlocked_length")]
        public int RewardItemMergeChainUnlockedLength { get; set; }

        public AnalyticsEventDailyTaskFirstImpression(string taskId, int taskIndex, string requiredItem, int requiredItemCount, string rewardItem, int rewardItemCount, string localDateTime, string dailyTasksSetId, string dailyTasksFinalRewardsId, bool isPurchasedTask, int requiredItemLevel, int requiredItemMergeChainTotalLength, int requiredItemMergeChainUnlockedLength, int rewardItemLevel, int rewardItemMergeChainTotalLength, int rewardItemMergeChainUnlockedLength)
        {
        }
    }
}