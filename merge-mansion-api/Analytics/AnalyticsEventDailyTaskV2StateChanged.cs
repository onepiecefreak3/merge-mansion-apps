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

        [Description("")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("task_type")]
        public string TaskType { get; set; }

        [Description("Unique daily cycle task set id")]
        [JsonProperty("daily_tasks_set_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string TasksSetId { get; set; }

        [Description("Current daily cycle completion streak count")]
        [JsonProperty("streak_count")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public int StreakCount { get; set; }

        [Description("Task index")]
        [JsonProperty("task_index")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public int TaskIndex { get; set; }

        [Description("Task step number")]
        [JsonProperty("step_number")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public int StepNumber { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("state")]
        [Description("Task step state")]
        public string State { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("completion_type")]
        [Description("Task step completion type if just completed")]
        public string CompletionType { get; set; }

        [JsonProperty("gems_spent")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Gems spent to complete the task step if just completed by purchasing")]
        public int GemsSpent { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("keys_received")]
        [Description("Keys received for the daily cycle completion reward (chest)")]
        public int KeysReceived { get; set; }

        [Description("Required item id")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("required_item")]
        public string RequiredItem { get; set; }

        [JsonProperty("required_item_level")]
        [Description("Required item level")]
        [MetaMember(11, (MetaMemberFlags)0)]
        public int RequiredItemLevel { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("required_item_count")]
        [Description("Required item count")]
        public int RequiredItemCount { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Required item's total merge chain length")]
        [JsonProperty("required_item_mergechain_total_length")]
        public int RequiredItemMergeChainTotalLength { get; set; }

        [JsonProperty("required_item_mergechain_unlocked_length")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [Description("Required item's unlocked merge chain length")]
        public int RequiredItemMergeChainUnlockedLength { get; set; }

        [Description("Reward item id")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [JsonProperty("reward_item")]
        public string RewardItem { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("reward_item_level")]
        [Description("Reward item level")]
        public int RewardItemLevel { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        [JsonProperty("reward_item_count")]
        [Description("Reward item count")]
        public int RewardItemCount { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        [JsonProperty("reward_item_mergechain_total_length")]
        [Description("Reward item's total merge chain length")]
        public int RewardItemMergeChainTotalLength { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        [JsonProperty("reward_item_mergechain_unlocked_length")]
        [Description("Reward item's unlocked merge chain length")]
        public int RewardItemMergeChainUnlockedLength { get; set; }

        [MetaMember(20, (MetaMemberFlags)0)]
        [JsonProperty("local_datetime")]
        [Description("Player's local date and time")]
        public string LocalDateTime { get; set; }

        [Description("Gems required to complete the task step by purchasing")]
        [JsonProperty("price_to_complete")]
        [MetaMember(21, (MetaMemberFlags)0)]
        public int GemsPriceToComplete { get; set; }

        [MetaMember(22, (MetaMemberFlags)0)]
        [JsonProperty("price_to_refresh")]
        [Description("Gems required to refresh the task step")]
        public int GemsPriceToRefresh { get; set; }

        [JsonProperty("required_item_value")]
        [Description("Required item value")]
        [MetaMember(23, (MetaMemberFlags)0)]
        public int RequiredItemValue { get; set; }

        [JsonProperty("reward_item_value")]
        [MetaMember(24, (MetaMemberFlags)0)]
        [Description("Reward item value")]
        public int RewardItemValue { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventDailyTaskV2StateChanged()
        {
        }
    }
}