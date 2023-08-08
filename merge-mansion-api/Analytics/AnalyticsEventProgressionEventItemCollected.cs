using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using Merge;
using Metaplay.Core;

namespace Analytics
{
    [AnalyticsEvent(152, "Progression event item collected", 1, null, false, true, false)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class AnalyticsEventProgressionEventItemCollected : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("event_id")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Event where progress was made")]
        public string EventId { get; set; }

        [JsonProperty("board_id")]
        [Description("Board where event item was collected")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public MergeBoardId BoardId { get; set; }

        [JsonProperty("event_progress_gained")]
        [Description("How many points player made")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public int EventProgressGained { get; set; }

        [Description("True if item was collected from inventory")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("from_inventory")]
        public bool FromInventory { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Collected item")]
        [JsonProperty("item_name")]
        public string ItemType { get; set; }
        public override string EventDescription { get; }

        private AnalyticsEventProgressionEventItemCollected()
        {
        }

        public AnalyticsEventProgressionEventItemCollected(IStringId eventId, MergeBoardId boardId, int eventProgressGained, bool fromInventory, string itemType)
        {
        }
    }
}