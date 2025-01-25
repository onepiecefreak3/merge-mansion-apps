using Metaplay.Core.Analytics;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [AnalyticsEvent(144, "Garage cleanup item turned in", 1, null, true, true, false)]
    [AnalyticsEventKeywords(new string[] { "event" })]
    public class AnalyticsEventGarageCleanupSlotFilled : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("event_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Garage cleanup event id")]
        public string EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Id of the required item")]
        [JsonProperty("required_item")]
        public string RequiredItem { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("board_level")]
        [Description("Level of the board")]
        public int BoardLevel { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Slot's row index (aka y axis)")]
        [JsonProperty("row_index")]
        public int RowIndex { get; set; }

        [JsonProperty("column_index")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Slot's column index (aka x axis)")]
        public int ColumnIndex { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventGarageCleanupSlotFilled()
        {
        }

        public AnalyticsEventGarageCleanupSlotFilled(string eventId, string requiredItem, int boardLevel, int rowIndex, int columnIndex)
        {
        }
    }
}