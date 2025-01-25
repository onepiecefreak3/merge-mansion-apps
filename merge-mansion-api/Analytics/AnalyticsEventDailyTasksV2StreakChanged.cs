using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace Analytics
{
    [AnalyticsEvent(194, "Daily Tasks V2 streak changed", 1, null, false, true, false)]
    public class AnalyticsEventDailyTasksV2StreakChanged : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("level")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("New streak count")]
        public int Level { get; set; }

        [JsonProperty("level_at_reset")]
        [Description("Streak count before if just reset")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public int LevelAtReset { get; set; }

        [Description("Keys spent to claim the daily cycle completion reward (chest)")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("keys_spent")]
        public int KeysSpent { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Daily cycle completion reward item id")]
        [JsonProperty("reward_item")]
        public string RewardItem { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventDailyTasksV2StreakChanged()
        {
        }
    }
}