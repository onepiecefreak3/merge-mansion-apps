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
    [AnalyticsEvent(138, "Board state snapshot", 1, null, false, true, false)]
    [MetaBlockedMembers(new int[] { 1, 2, 3, 8, 9, 10 })]
    public class AnalyticEventBoardState : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [Description("Partially visible Board items of all on-going boards")]
        [JsonProperty("partially_visible_board_items")]
        [MetaMember(15, (MetaMemberFlags)0)]
        public Dictionary<MergeBoardId, Dictionary<string, int>> PartiallyVisibleBoardItems { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("merge_goals")]
        [Description("Merge goals")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public List<HotspotId> MergeGoals { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("event_goals")]
        [Description("Event goals")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<EventId, List<EventTaskId>> EventGoals { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("board_items")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [Description("Board items of all on-going boards")]
        public Dictionary<MergeBoardId, List<AnalyticsBoardStateMetaData>> BoardItems { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("inventory_items")]
        [Description("Inventory items")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<MergeBoardId, List<AnalyticsBoardStateMetaData>> InventoryItems { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("pocket_items")]
        [Description("Pocket items")]
        public Dictionary<MergeBoardId, Dictionary<string, int>> PocketItems { get; set; }

        [Description("Decorations")]
        [JsonProperty("decorations")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public List<AnalyticsBoardStateDecorationMetaData> Decorations { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("inventory_items_extra")]
        [Description("Inventory items from extra perk")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<MergeBoardId, List<AnalyticsBoardStateMetaData>> InventoryExtraItems { get; set; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [Description("Hidden items count")]
        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("hidden_item_count")]
        public Dictionary<MergeBoardId, int> HiddenItemCount { get; set; }

        [JsonProperty("gathered_from")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [Description("Snapshot taken at session start or session end")]
        public AnalyticsSnapshotType SnapshotType { get; set; }
        public override string EventDescription { get; }

        public AnalyticEventBoardState()
        {
        }

        public AnalyticEventBoardState(PlayerModel player, AnalyticsSnapshotType snapshotType)
        {
        }

        [Description("Producer inventory items")]
        [JsonProperty("producer_inventory_items")]
        [MetaMember(17, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<MergeBoardId, List<AnalyticsBoardStateMetaData>> ProducerInventoryItems { get; set; }

        [Description("Rentable inventory items")]
        [JsonProperty("rentable_inventory_items")]
        [MetaMember(18, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<MergeBoardId, List<AnalyticsBoardStateMetaData>> RentableInventoryItems { get; set; }

        [Description("Pets")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(19, (MetaMemberFlags)0)]
        [JsonProperty("pets")]
        public List<AnalyticsBoardStateDecorationMetaData> Pets { get; set; }
    }
}