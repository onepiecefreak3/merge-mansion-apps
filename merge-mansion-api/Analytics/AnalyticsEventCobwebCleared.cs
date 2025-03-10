using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.Model;
using System;

namespace Analytics
{
    [AnalyticsEvent(180, "Cobweb cleared", 1, null, false, true, false)]
    public class AnalyticsEventCobwebCleared : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("event_id")]
        [Description("Board event id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string EventId { get; set; }

        [Description("Board id")]
        [JsonProperty("board_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string BoardId { get; set; }

        [JsonProperty("item_name")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Cleared item name")]
        public string ItemName { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Slot's row index (aka y axis)")]
        [JsonProperty("row_index")]
        public int RowIndex { get; set; }

        [Description("Slot's column index (aka x axis)")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("column_index")]
        public int ColumnIndex { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventCobwebCleared()
        {
        }

        public AnalyticsEventCobwebCleared(string eventId, string boardId, string itemName, int rowIndex, int columnIndex)
        {
        }
    }
}