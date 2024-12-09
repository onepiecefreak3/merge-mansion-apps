using Metaplay.Core.Model;
using Metaplay.Core.Analytics;
using System.ComponentModel;
using Newtonsoft.Json;
using Merge;
using System;
using Metaplay.Core;
using System.Collections.Generic;
using GameLogic.Player;

namespace Analytics
{
    [AnalyticsEvent(122, "Player snapshot", 1, null, false, true, false)]
    [MetaBlockedMembers(new int[] { 2, 3, 4, 5, 7, 9 })]
    public class AnalyticsEventPlayerSnapshot : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("gathered_from")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Point at which snapshot was gathered (0 - session start, 1 - session end, 2 - mid-session)")]
        public AnalyticsSnapshotType SnapshotType { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Player's current story event (if present) represented as event merge board ID")]
        [JsonProperty("current_event")]
        public MergeBoardId CurrentStoryEventBoardId { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("saldo_diamond_purchased")]
        [Description("Player's hard (purchased with real money) gems balance")]
        public long HardDiamondsSaldo { get; set; }

        [JsonProperty("saldo_coins_purchased")]
        [Description("Player's hard (purchased with real money) coins balance")]
        [MetaMember(10, (MetaMemberFlags)0)]
        public long HardCoinsSaldo { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        [JsonProperty("session_count_lt")]
        [Description("How many sessions player had over lifetime")]
        public long SessionCount { get; set; }

        [JsonProperty("lt_in_app_purchase_count")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("How many IAPs player purchased over lifetime")]
        public int TotalIAPBought { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Date of the first purchase")]
        [JsonProperty("first_purchase_date")]
        public MetaTime FirstPurchase { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        [Description("Date of the first session")]
        [JsonProperty("user_first_touch_timestamp")]
        public MetaTime FirstSession { get; set; }

        [Description("Engagement time in minutes")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [JsonProperty("engagement_time_min")]
        public double EngagementTimeInMin { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("merge_goals_completed")]
        [Description("How many merge goals player completed")]
        public int MergeGoalsCompleted { get; set; }

        [Description("How many merge goals player opened")]
        [MetaMember(17, (MetaMemberFlags)0)]
        [JsonProperty("merge_goals_open")]
        public int MergeGoalsOpen { get; set; }

        [Description("Game Events that have been interacted with (task completed and active)")]
        [MetaMember(18, (MetaMemberFlags)0)]
        [JsonProperty("game_events_interacted_and_active")]
        public string ActiveAndInteractedWithGameEvents { get; set; }

        [JsonProperty("music_is_muted")]
        [Description("Player music state, is the music muted or note")]
        [MetaMember(19, (MetaMemberFlags)0)]
        public bool MusicIsMuted { get; set; }

        [JsonProperty("sfx_is_muted")]
        [Description("Player sfx state, is the sfx muted or note")]
        [MetaMember(20, (MetaMemberFlags)0)]
        public bool SfxIsMuted { get; set; }

        [JsonProperty("garage_inventory_slots")]
        [MetaMember(21, (MetaMemberFlags)0)]
        [Description("Total amount of Garage inventory slots")]
        public int GarageInventorySlots { get; set; }

        [MetaMember(22, (MetaMemberFlags)0)]
        [JsonProperty("garage_free_inventory_slots")]
        [Description("Free amount of Garage inventory slots")]
        public int GarageFreeInventorySlots { get; set; }

        [JsonProperty("empty_board_slots")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [Description("Empty board slot counts")]
        [MetaMember(23, (MetaMemberFlags)0)]
        public Dictionary<string, int> EmptyBoardSlots { get; set; }

        [JsonProperty("hidden_board_items")]
        [MetaMember(24, (MetaMemberFlags)0)]
        [Description("Empty board slot counts")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<MergeBoardId, int> HiddenBoardItems { get; set; }

        [Description("Empty board slot counts")]
        [MetaMember(25, (MetaMemberFlags)0)]
        [JsonProperty("lt_in_app_purchase_revenue")]
        public float TotalIAPRevenue { get; set; }

        [Description("Total merges since 2204 update")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("merge_counts")]
        [MetaMember(26, (MetaMemberFlags)0)]
        public Dictionary<MergeBoardId, int> MergeCounts { get; set; }

        [Description("String describing approximate location")]
        [MetaMember(27, (MetaMemberFlags)0)]
        [JsonProperty("location")]
        public string Location { get; set; }

        [Description("String identifying the device")]
        [JsonProperty("device")]
        [MetaMember(28, (MetaMemberFlags)0)]
        public string Device { get; set; }

        [Description("String identifying the device")]
        [MetaMember(29, (MetaMemberFlags)0)]
        [JsonProperty("platform")]
        public ClientPlatform Platform { get; set; }

        [MetaMember(30, (MetaMemberFlags)0)]
        [JsonProperty("merge_goals_count_exclude_unlock")]
        [Description("How many merge goals player has excluding area unlocks")]
        public int MergeGoalsOpenExcludeUnlock { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventPlayerSnapshot()
        {
        }

        public AnalyticsEventPlayerSnapshot(PlayerModel player, AnalyticsSnapshotType snapshotType)
        {
        }

        [JsonProperty("merge_hints_are_on")]
        [MetaMember(31, (MetaMemberFlags)0)]
        [Description("Are merge hints enabled or not")]
        public bool MergeHintsAreOn { get; set; }

        [MetaMember(32, (MetaMemberFlags)0)]
        [JsonProperty("producer_inventory_slots")]
        [Description("Total amount of Producer inventory slots")]
        public int ProducerInventorySlots { get; set; }

        [JsonProperty("free_producer_inventory_slots")]
        [MetaMember(33, (MetaMemberFlags)0)]
        [Description("Free amount of Producer inventory slots")]
        public int FreeProducerInventorySlots { get; set; }

        [MetaMember(34, (MetaMemberFlags)0)]
        [JsonProperty("haptics_is_on")]
        [Description("Player haptics state, are the haptics on or off")]
        public bool HapticsIsOn { get; set; }
    }
}