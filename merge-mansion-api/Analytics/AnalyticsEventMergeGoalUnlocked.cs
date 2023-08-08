using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using System;
using GameLogic.Player;
using GameLogic.Hotspots;

namespace Analytics
{
    [AnalyticsEvent(101, "Merge goal unlocked", 1, null, false, true, false)]
    public class AnalyticsEventMergeGoalUnlocked : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("goal_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("ID of the opened hotspot")]
        public HotspotId HotspotId { get; set; }

        [JsonProperty("area_name")]
        [Description("Area that was unlocked")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string AreaName { get; set; }

        [JsonProperty("merge_goals_open")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("How many merge goals open")]
        public int MergeGoalsOpen { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventMergeGoalUnlocked()
        {
        }

        public AnalyticsEventMergeGoalUnlocked(PlayerModel player, HotspotDefinition hotspotDefinition)
        {
        }
    }
}