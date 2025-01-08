using Metaplay.Core.Model;
using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Collections.Generic;
using Merge;
using System;
using Code.GameLogic.GameEvents;
using GameLogic;
using GameLogic.Player;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 1, 2, 3, 8, 9, 10 })]
    [AnalyticsEvent(138, "Board state snapshot", 1, null, false, true, false)]
    public class AnalyticEventBoardState : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [Description("Partially visible Board items of all on-going boards")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [JsonProperty("partially_visible_board_items")]
        public Dictionary<MergeBoardId, Dictionary<string, int>> PartiallyVisibleBoardItems { get; set; }

        [Description("Merge goals")]
        [JsonProperty("merge_goals")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(4, (MetaMemberFlags)0)]
        public List<HotspotId> MergeGoals { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("event_goals")]
        [Description("Event goals")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<EventId, List<EventTaskId>> EventGoals { get; set; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("board_items")]
        [Description("Board items of all on-going boards")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public Dictionary<MergeBoardId, List<AnalyticsBoardStateMetaData>> BoardItems { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("inventory_items")]
        [Description("Inventory items")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<MergeBoardId, List<AnalyticsBoardStateMetaData>> InventoryItems { get; set; }

        [Description("Pocket items")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("pocket_items")]
        [MetaMember(16, (MetaMemberFlags)0)]
        public Dictionary<MergeBoardId, Dictionary<string, int>> PocketItems { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        [Description("Decorations")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("decorations")]
        public List<AnalyticsBoardStateDecorationMetaData> Decorations { get; set; }

        [JsonProperty("inventory_items_extra")]
        [Description("Inventory items from extra perk")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(12, (MetaMemberFlags)0)]
        public Dictionary<MergeBoardId, List<AnalyticsBoardStateMetaData>> InventoryExtraItems { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("hidden_item_count")]
        [Description("Hidden items count")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<MergeBoardId, int> HiddenItemCount { get; set; }

        [Description("Snapshot taken at session start or session end")]
        [JsonProperty("gathered_from")]
        [MetaMember(14, (MetaMemberFlags)0)]
        public AnalyticsSnapshotType SnapshotType { get; set; }
        public override string EventDescription { get; }

        public AnalyticEventBoardState()
        {
        }

        public AnalyticEventBoardState(PlayerModel player, AnalyticsSnapshotType snapshotType)
        {
        }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("producer_inventory_items")]
        [Description("Producer inventory items")]
        [MetaMember(17, (MetaMemberFlags)0)]
        public Dictionary<MergeBoardId, List<AnalyticsBoardStateMetaData>> ProducerInventoryItems { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        [JsonProperty("rentable_inventory_items")]
        [Description("Rentable inventory items")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<MergeBoardId, List<AnalyticsBoardStateMetaData>> RentableInventoryItems { get; set; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(19, (MetaMemberFlags)0)]
        [JsonProperty("pets")]
        [Description("Pets")]
        public List<AnalyticsBoardStateDecorationMetaData> Pets { get; set; }
    }
}