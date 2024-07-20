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

        [Description("Point at which snapshot was gathered (0 - session start, 1 - session end, 2 - mid-session)")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("gathered_from")]
        public AnalyticsSnapshotType SnapshotType { get; set; }

        [JsonProperty("current_event")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Player's current story event (if present) represented as event merge board ID")]
        public MergeBoardId CurrentStoryEventBoardId { get; set; }

        [JsonProperty("saldo_diamond_purchased")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Player's hard (purchased with real money) gems balance")]
        public long HardDiamondsSaldo { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Player's hard (purchased with real money) coins balance")]
        [JsonProperty("saldo_coins_purchased")]
        public long HardCoinsSaldo { get; set; }

        [JsonProperty("session_count_lt")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [Description("How many sessions player had over lifetime")]
        public long SessionCount { get; set; }

        [JsonProperty("lt_in_app_purchase_count")]
        [Description("How many IAPs player purchased over lifetime")]
        [MetaMember(12, (MetaMemberFlags)0)]
        public int TotalIAPBought { get; set; }

        [Description("Date of the first purchase")]
        [JsonProperty("first_purchase_date")]
        [MetaMember(13, (MetaMemberFlags)0)]
        public MetaTime FirstPurchase { get; set; }

        [JsonProperty("user_first_touch_timestamp")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [Description("Date of the first session")]
        public MetaTime FirstSession { get; set; }

        [Description("Engagement time in minutes")]
        [JsonProperty("engagement_time_min")]
        [MetaMember(15, (MetaMemberFlags)0)]
        public double EngagementTimeInMin { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        [Description("How many merge goals player completed")]
        [JsonProperty("merge_goals_completed")]
        public int MergeGoalsCompleted { get; set; }

        [Description("How many merge goals player opened")]
        [MetaMember(17, (MetaMemberFlags)0)]
        [JsonProperty("merge_goals_open")]
        public int MergeGoalsOpen { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        [JsonProperty("game_events_interacted_and_active")]
        [Description("Game Events that have been interacted with (task completed and active)")]
        public string ActiveAndInteractedWithGameEvents { get; set; }

        [Description("Player music state, is the music muted or note")]
        [MetaMember(19, (MetaMemberFlags)0)]
        [JsonProperty("music_is_muted")]
        public bool MusicIsMuted { get; set; }

        [JsonProperty("sfx_is_muted")]
        [MetaMember(20, (MetaMemberFlags)0)]
        [Description("Player sfx state, is the sfx muted or note")]
        public bool SfxIsMuted { get; set; }

        [JsonProperty("garage_inventory_slots")]
        [MetaMember(21, (MetaMemberFlags)0)]
        [Description("Total amount of Garage inventory slots")]
        public int GarageInventorySlots { get; set; }

        [JsonProperty("garage_free_inventory_slots")]
        [Description("Free amount of Garage inventory slots")]
        [MetaMember(22, (MetaMemberFlags)0)]
        public int GarageFreeInventorySlots { get; set; }

        [MetaMember(23, (MetaMemberFlags)0)]
        [Description("Empty board slot counts")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("empty_board_slots")]
        public Dictionary<string, int> EmptyBoardSlots { get; set; }

        [JsonProperty("hidden_board_items")]
        [MetaMember(24, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [Description("Empty board slot counts")]
        public Dictionary<MergeBoardId, int> HiddenBoardItems { get; set; }

        [JsonProperty("lt_in_app_purchase_revenue")]
        [MetaMember(25, (MetaMemberFlags)0)]
        [Description("Empty board slot counts")]
        public float TotalIAPRevenue { get; set; }

        [MetaMember(26, (MetaMemberFlags)0)]
        [JsonProperty("merge_counts")]
        [Description("Total merges since 2204 update")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<MergeBoardId, int> MergeCounts { get; set; }

        [MetaMember(27, (MetaMemberFlags)0)]
        [Description("String describing approximate location")]
        [JsonProperty("location")]
        public string Location { get; set; }

        [MetaMember(28, (MetaMemberFlags)0)]
        [Description("String identifying the device")]
        [JsonProperty("device")]
        public string Device { get; set; }

        [MetaMember(29, (MetaMemberFlags)0)]
        [Description("String identifying the device")]
        [JsonProperty("platform")]
        public ClientPlatform Platform { get; set; }

        [JsonProperty("merge_goals_count_exclude_unlock")]
        [Description("How many merge goals player has excluding area unlocks")]
        [MetaMember(30, (MetaMemberFlags)0)]
        public int MergeGoalsOpenExcludeUnlock { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventPlayerSnapshot()
        {
        }

        public AnalyticsEventPlayerSnapshot(PlayerModel player, AnalyticsSnapshotType snapshotType)
        {
        }

        [Description("Are merge hints enabled or not")]
        [MetaMember(31, (MetaMemberFlags)0)]
        [JsonProperty("merge_hints_are_on")]
        public bool MergeHintsAreOn { get; set; }

        [Description("Total amount of Producer inventory slots")]
        [MetaMember(32, (MetaMemberFlags)0)]
        [JsonProperty("producer_inventory_slots")]
        public int ProducerInventorySlots { get; set; }

        [JsonProperty("free_producer_inventory_slots")]
        [MetaMember(33, (MetaMemberFlags)0)]
        [Description("Free amount of Producer inventory slots")]
        public int FreeProducerInventorySlots { get; set; }
    }
}