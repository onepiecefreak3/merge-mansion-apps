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

        [Description("Garage cleanup event id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [Description("Id of the required item")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("required_item")]
        public string RequiredItem { get; set; }

        [JsonProperty("board_level")]
        [Description("Level of the board")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public int BoardLevel { get; set; }

        [JsonProperty("row_index")]
        [Description("Slot's row index (aka y axis)")]
        [MetaMember(4, (MetaMemberFlags)0)]
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