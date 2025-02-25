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
    [MetaBlockedMembers(new int[] { 2, 3, 4, 5, 7, 9 })]
    [AnalyticsEvent(122, "Player snapshot", 1, null, false, true, false)]
    public class AnalyticsEventPlayerSnapshot : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("gathered_from")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Point at which snapshot was gathered (0 - session start, 1 - session end, 2 - mid-session)")]
        public AnalyticsSnapshotType SnapshotType { get; set; }

        [JsonProperty("current_event")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Player's current story event (if present) represented as event merge board ID")]
        public MergeBoardId CurrentStoryEventBoardId { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Player's hard (purchased with real money) gems balance")]
        [JsonProperty("saldo_diamond_purchased")]
        public long HardDiamondsSaldo { get; set; }

        [JsonProperty("saldo_coins_purchased")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Player's hard (purchased with real money) coins balance")]
        public long HardCoinsSaldo { get; set; }

        [JsonProperty("session_count_lt")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [Description("How many sessions player had over lifetime")]
        public long SessionCount { get; set; }

        [Description("How many IAPs player purchased over lifetime")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("lt_in_app_purchase_count")]
        public int TotalIAPBought { get; set; }

        [JsonProperty("first_purchase_date")]
        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Date of the first purchase")]
        public MetaTime FirstPurchase { get; set; }

        [JsonProperty("user_first_touch_timestamp")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [Description("Date of the first session")]
        public MetaTime FirstSession { get; set; }

        [JsonProperty("engagement_time_min")]
        [Description("Engagement time in minutes")]
        [MetaMember(15, (MetaMemberFlags)0)]
        public double EngagementTimeInMin { get; set; }

        [Description("How many merge goals player completed")]
        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("merge_goals_completed")]
        public int MergeGoalsCompleted { get; set; }

        [Description("How many merge goals player opened")]
        [MetaMember(17, (MetaMemberFlags)0)]
        [JsonProperty("merge_goals_open")]
        public int MergeGoalsOpen { get; set; }

        [Description("Game Events that have been interacted with (task completed and active)")]
        [JsonProperty("game_events_interacted_and_active")]
        [MetaMember(18, (MetaMemberFlags)0)]
        public string ActiveAndInteractedWithGameEvents { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        [Description("Player music state, is the music muted or note")]
        [JsonProperty("music_is_muted")]
        public bool MusicIsMuted { get; set; }

        [JsonProperty("sfx_is_muted")]
        [Description("Player sfx state, is the sfx muted or note")]
        [MetaMember(20, (MetaMemberFlags)0)]
        public bool SfxIsMuted { get; set; }

        [Description("Total amount of Garage inventory slots")]
        [MetaMember(21, (MetaMemberFlags)0)]
        [JsonProperty("garage_inventory_slots")]
        public int GarageInventorySlots { get; set; }

        [JsonProperty("garage_free_inventory_slots")]
        [Description("Free amount of Garage inventory slots")]
        [MetaMember(22, (MetaMemberFlags)0)]
        public int GarageFreeInventorySlots { get; set; }

        [JsonProperty("empty_board_slots")]
        [Description("Empty board slot counts")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(23, (MetaMemberFlags)0)]
        public Dictionary<string, int> EmptyBoardSlots { get; set; }

        [Description("Empty board slot counts")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("hidden_board_items")]
        [MetaMember(24, (MetaMemberFlags)0)]
        public Dictionary<MergeBoardId, int> HiddenBoardItems { get; set; }

        [Description("Empty board slot counts")]
        [MetaMember(25, (MetaMemberFlags)0)]
        [JsonProperty("lt_in_app_purchase_revenue")]
        public float TotalIAPRevenue { get; set; }

        [Description("Total merges since 2204 update")]
        [MetaMember(26, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("merge_counts")]
        public Dictionary<MergeBoardId, int> MergeCounts { get; set; }

        [JsonProperty("location")]
        [MetaMember(27, (MetaMemberFlags)0)]
        [Description("String describing approximate location")]
        public string Location { get; set; }

        [Description("String identifying the device")]
        [JsonProperty("device")]
        [MetaMember(28, (MetaMemberFlags)0)]
        public string Device { get; set; }

        [JsonProperty("platform")]
        [MetaMember(29, (MetaMemberFlags)0)]
        [Description("String identifying the device")]
        public ClientPlatform Platform { get; set; }

        [JsonProperty("merge_goals_count_exclude_unlock")]
        [MetaMember(30, (MetaMemberFlags)0)]
        [Description("How many merge goals player has excluding area unlocks")]
        public int MergeGoalsOpenExcludeUnlock { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventPlayerSnapshot()
        {
        }

        public AnalyticsEventPlayerSnapshot(PlayerModel player, AnalyticsSnapshotType snapshotType)
        {
        }

        [MetaMember(31, (MetaMemberFlags)0)]
        [JsonProperty("merge_hints_are_on")]
        [Description("Are merge hints enabled or not")]
        public bool MergeHintsAreOn { get; set; }

        [Description("Total amount of Producer inventory slots")]
        [JsonProperty("producer_inventory_slots")]
        [MetaMember(32, (MetaMemberFlags)0)]
        public int ProducerInventorySlots { get; set; }

        [MetaMember(33, (MetaMemberFlags)0)]
        [Description("Free amount of Producer inventory slots")]
        [JsonProperty("free_producer_inventory_slots")]
        public int FreeProducerInventorySlots { get; set; }

        [MetaMember(34, (MetaMemberFlags)0)]
        [JsonProperty("haptics_is_on")]
        [Description("Player haptics state, are the haptics on or off")]
        public bool HapticsIsOn { get; set; }
    }
}