using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using System;
using GameLogic;
using GameLogic.Player;
using GameLogic.Hotspots;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 6 })]
    [AnalyticsEvent(101, "Merge goal unlocked", 1, null, false, true, false)]
    public class AnalyticsEventMergeGoalUnlocked : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("goal_id")]
        [Description("ID of the opened hotspot")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public HotspotId HotspotId { get; set; }

        [Description("Area that was unlocked")]
        [JsonProperty("area_name")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string AreaName { get; set; }

        [Description("How many merge goals open")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("merge_goals_open")]
        public int MergeGoalsOpen { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventMergeGoalUnlocked()
        {
        }

        public AnalyticsEventMergeGoalUnlocked(PlayerModel player, HotspotDefinition hotspotDefinition)
        {
        }

        [JsonProperty("map_spot_id")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("MapSpot where the hotspot is located")]
        public string MapSpot { get; set; }

        [JsonProperty("task_group_id")]
        [Description("Multistep Group Id of the hotspot task (may be empty)")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public string TaskGroup { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("How much time is left for bonus")]
        [JsonProperty("bonus_time_left")]
        public double? BonusTimeLeft { get; set; }

        [Description("Possible bonus rewards")]
        [JsonProperty("bonus_rewards")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public AnalyticsPlayerBonusReward[] BonusRewards { get; set; }

        [JsonProperty("character_id")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Character id of the hotspot task (may be empty)")]
        public string Character { get; set; }
    }
}