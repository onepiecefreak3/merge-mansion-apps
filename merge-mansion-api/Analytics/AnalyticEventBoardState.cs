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

        [Description("Partially visible Board items of all on-going boards")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(15, (MetaMemberFlags)0)]
        [JsonProperty("partially_visible_board_items")]
        public Dictionary<MergeBoardId, Dictionary<string, int>> PartiallyVisibleBoardItems { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("merge_goals")]
        [Description("Merge goals")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public List<HotspotId> MergeGoals { get; set; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("event_goals")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Event goals")]
        public Dictionary<EventId, List<EventTaskId>> EventGoals { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("board_items")]
        [Description("Board items of all on-going boards")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<MergeBoardId, List<AnalyticsBoardStateMetaData>> BoardItems { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("inventory_items")]
        [Description("Inventory items")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<MergeBoardId, List<AnalyticsBoardStateMetaData>> InventoryItems { get; set; }

        [Description("Pocket items")]
        [JsonProperty("pocket_items")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(16, (MetaMemberFlags)0)]
        public Dictionary<MergeBoardId, Dictionary<string, int>> PocketItems { get; set; }

        [JsonProperty("decorations")]
        [Description("Decorations")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(11, (MetaMemberFlags)0)]
        public List<AnalyticsBoardStateDecorationMetaData> Decorations { get; set; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [Description("Inventory items from extra perk")]
        [JsonProperty("inventory_items_extra")]
        [MetaMember(12, (MetaMemberFlags)0)]
        public Dictionary<MergeBoardId, List<AnalyticsBoardStateMetaData>> InventoryExtraItems { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("hidden_item_count")]
        [Description("Hidden items count")]
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
        [MetaMember(17, (MetaMemberFlags)0)]
        [JsonProperty("producer_inventory_items")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<MergeBoardId, List<AnalyticsBoardStateMetaData>> ProducerInventoryItems { get; set; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(18, (MetaMemberFlags)0)]
        [JsonProperty("rentable_inventory_items")]
        [Description("Rentable inventory items")]
        public Dictionary<MergeBoardId, List<AnalyticsBoardStateMetaData>> RentableInventoryItems { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        [Description("Pets")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("pets")]
        public List<AnalyticsBoardStateDecorationMetaData> Pets { get; set; }
    }
}