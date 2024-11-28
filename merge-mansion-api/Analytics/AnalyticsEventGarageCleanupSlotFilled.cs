using Metaplay.Core.Analytics;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [AnalyticsEvent(144, "Garage cleanup item turned in", 1, null, true, true, false)]
    public class AnalyticsEventGarageCleanupSlotFilled : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("event_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Garage cleanup event id")]
        public string EventId { get; set; }

        [JsonProperty("required_item")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Id of the required item")]
        public string RequiredItem { get; set; }

        [Description("Level of the board")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("board_level")]
        public int BoardLevel { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Slot's row index (aka y axis)")]
        [JsonProperty("row_index")]
        public int RowIndex { get; set; }

        [Description("Slot's column index (aka x axis)")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("column_index")]
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