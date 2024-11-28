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

        [Description("New streak count")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("level_at_reset")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Streak count before if just reset")]
        public int LevelAtReset { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("keys_spent")]
        [Description("Keys spent to claim the daily cycle completion reward (chest)")]
        public int KeysSpent { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("reward_item")]
        [Description("Daily cycle completion reward item id")]
        public string RewardItem { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventDailyTasksV2StreakChanged()
        {
        }
    }
}