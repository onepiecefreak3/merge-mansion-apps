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
    [AnalyticsEvent(101, "Merge goal unlocked", 1, null, false, true, false)]
    [MetaBlockedMembers(new int[] { 6 })]
    public class AnalyticsEventMergeGoalUnlocked : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("ID of the opened hotspot")]
        [JsonProperty("goal_id")]
        public HotspotId HotspotId { get; set; }

        [JsonProperty("area_name")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Area that was unlocked")]
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

        [JsonProperty("map_spot_id")]
        [Description("MapSpot where the hotspot is located")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public string MapSpot { get; set; }

        [Description("Multistep Group Id of the hotspot task (may be empty)")]
        [JsonProperty("task_group_id")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public string TaskGroup { get; set; }

        [JsonProperty("bonus_time_left")]
        [Description("How much time is left for bonus")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public double? BonusTimeLeft { get; set; }

        [JsonProperty("bonus_rewards")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Possible bonus rewards")]
        public AnalyticsPlayerBonusReward[] BonusRewards { get; set; }

        [JsonProperty("character_id")]
        [Description("Character id of the hotspot task (may be empty)")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public string Character { get; set; }
    }
}