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

        [JsonProperty("task_type")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("")]
        public string TaskType { get; set; }

        [Description("Unique daily cycle task set id")]
        [JsonProperty("daily_tasks_set_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string TasksSetId { get; set; }

        [JsonProperty("streak_count")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Current daily cycle completion streak count")]
        public int StreakCount { get; set; }

        [JsonProperty("task_index")]
        [Description("Task index")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public int TaskIndex { get; set; }

        [JsonProperty("step_number")]
        [Description("Task step number")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public int StepNumber { get; set; }

        [JsonProperty("state")]
        [Description("Task step state")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public string State { get; set; }

        [Description("Task step completion type if just completed")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("completion_type")]
        public string CompletionType { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("gems_spent")]
        [Description("Gems spent to complete the task step if just completed by purchasing")]
        public int GemsSpent { get; set; }

        [JsonProperty("keys_received")]
        [Description("Keys received for the daily cycle completion reward (chest)")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public int KeysReceived { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("required_item")]
        [Description("Required item id")]
        public string RequiredItem { get; set; }

        [JsonProperty("required_item_level")]
        [Description("Required item level")]
        [MetaMember(11, (MetaMemberFlags)0)]
        public int RequiredItemLevel { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("Required item count")]
        [JsonProperty("required_item_count")]
        public int RequiredItemCount { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("required_item_mergechain_total_length")]
        [Description("Required item's total merge chain length")]
        public int RequiredItemMergeChainTotalLength { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        [JsonProperty("required_item_mergechain_unlocked_length")]
        [Description("Required item's unlocked merge chain length")]
        public int RequiredItemMergeChainUnlockedLength { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        [JsonProperty("reward_item")]
        [Description("Reward item id")]
        public string RewardItem { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("reward_item_level")]
        [Description("Reward item level")]
        public int RewardItemLevel { get; set; }

        [JsonProperty("reward_item_count")]
        [MetaMember(17, (MetaMemberFlags)0)]
        [Description("Reward item count")]
        public int RewardItemCount { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        [JsonProperty("reward_item_mergechain_total_length")]
        [Description("Reward item's total merge chain length")]
        public int RewardItemMergeChainTotalLength { get; set; }

        [JsonProperty("reward_item_mergechain_unlocked_length")]
        [MetaMember(19, (MetaMemberFlags)0)]
        [Description("Reward item's unlocked merge chain length")]
        public int RewardItemMergeChainUnlockedLength { get; set; }

        [Description("Player's local date and time")]
        [JsonProperty("local_datetime")]
        [MetaMember(20, (MetaMemberFlags)0)]
        public string LocalDateTime { get; set; }

        [JsonProperty("price_to_complete")]
        [MetaMember(21, (MetaMemberFlags)0)]
        [Description("Gems required to complete the task step by purchasing")]
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
        [Description("Reward item value")]
        [MetaMember(24, (MetaMemberFlags)0)]
        public int RewardItemValue { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventDailyTaskV2StateChanged()
        {
        }
    }
}