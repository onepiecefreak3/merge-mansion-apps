using Metaplay.Core.Analytics;
using System;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Analytics
{
    [AnalyticsEvent(193, "Daily Task V2 state changed", 1, null, false, true, false)]
    public class AnalyticsEventDailyTaskV2StateChanged : AnalyticsServersideEventBase
    {
        private static string CompletionType_Purchase;
        private static string CompletionType_Trade;
        private static string State_Completed;
        private static string State_Impression;
        private static string State_Refresh;
        private static string TaskTypeId;
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("task_type")]
        [Description("")]
        public string TaskType { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("daily_tasks_set_id")]
        [Description("Unique daily cycle task set id")]
        public string TasksSetId { get; set; }

        [Description("Current daily cycle completion streak count")]
        [JsonProperty("streak_count")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public int StreakCount { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Task index")]
        [JsonProperty("task_index")]
        public int TaskIndex { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("step_number")]
        [Description("Task step number")]
        public int StepNumber { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("state")]
        [Description("Task step state")]
        public string State { get; set; }

        [Description("Task step completion type if just completed")]
        [JsonProperty("completion_type")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public string CompletionType { get; set; }

        [Description("Gems spent to complete the task step if just completed by purchasing")]
        [JsonProperty("gems_spent")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public int GemsSpent { get; set; }

        [JsonProperty("keys_received")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Keys received for the daily cycle completion reward (chest)")]
        public int KeysReceived { get; set; }

        [Description("Required item id")]
        [JsonProperty("required_item")]
        [MetaMember(10, (MetaMemberFlags)0)]
        public string RequiredItem { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        [JsonProperty("required_item_level")]
        [Description("Required item level")]
        public int RequiredItemLevel { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("required_item_count")]
        [Description("Required item count")]
        public int RequiredItemCount { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Required item's total merge chain length")]
        [JsonProperty("required_item_mergechain_total_length")]
        public int RequiredItemMergeChainTotalLength { get; set; }

        [Description("Required item's unlocked merge chain length")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [JsonProperty("required_item_mergechain_unlocked_length")]
        public int RequiredItemMergeChainUnlockedLength { get; set; }

        [Description("Reward item id")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [JsonProperty("reward_item")]
        public string RewardItem { get; set; }

        [Description("Reward item level")]
        [JsonProperty("reward_item_level")]
        [MetaMember(16, (MetaMemberFlags)0)]
        public int RewardItemLevel { get; set; }

        [Description("Reward item count")]
        [JsonProperty("reward_item_count")]
        [MetaMember(17, (MetaMemberFlags)0)]
        public int RewardItemCount { get; set; }

        [Description("Reward item's total merge chain length")]
        [MetaMember(18, (MetaMemberFlags)0)]
        [JsonProperty("reward_item_mergechain_total_length")]
        public int RewardItemMergeChainTotalLength { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        [JsonProperty("reward_item_mergechain_unlocked_length")]
        [Description("Reward item's unlocked merge chain length")]
        public int RewardItemMergeChainUnlockedLength { get; set; }

        [JsonProperty("local_datetime")]
        [MetaMember(20, (MetaMemberFlags)0)]
        [Description("Player's local date and time")]
        public string LocalDateTime { get; set; }

        [Description("Gems required to complete the task step by purchasing")]
        [MetaMember(21, (MetaMemberFlags)0)]
        [JsonProperty("price_to_complete")]
        public int GemsPriceToComplete { get; set; }

        [Description("Gems required to refresh the task step")]
        [JsonProperty("price_to_refresh")]
        [MetaMember(22, (MetaMemberFlags)0)]
        public int GemsPriceToRefresh { get; set; }

        [Description("Required item value")]
        [MetaMember(23, (MetaMemberFlags)0)]
        [JsonProperty("required_item_value")]
        public int RequiredItemValue { get; set; }

        [Description("Reward item value")]
        [JsonProperty("reward_item_value")]
        [MetaMember(24, (MetaMemberFlags)0)]
        public int RewardItemValue { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventDailyTaskV2StateChanged()
        {
        }
    }
}