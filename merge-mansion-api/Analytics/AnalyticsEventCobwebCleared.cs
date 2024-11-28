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

        [Description("Board event id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [JsonProperty("board_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Board id")]
        public string BoardId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Cleared item name")]
        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("row_index")]
        [Description("Slot's row index (aka y axis)")]
        public int RowIndex { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Slot's column index (aka x axis)")]
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