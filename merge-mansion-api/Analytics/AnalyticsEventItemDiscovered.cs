using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace Analytics
{
    [AnalyticsEvent(117, "Item discovered first time", 1, null, true, true, false)]
    public class AnalyticsEventItemDiscovered : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("item_name")]
        [Description("Discovered item")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [MetaOnMemberDeserializationFailure("FixItemType")]
        public string ItemName { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventItemDiscovered()
        {
        }

        public AnalyticsEventItemDiscovered(string itemName)
        {
        }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("item_level")]
        [Description("Discovered item level")]
        public int ItemLevel { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Merge chain total length of the discovered item")]
        [JsonProperty("item_mergechain_total_length")]
        public int ItemMergeChainTotalLength { get; set; }

        [Description("Merge chain unlocked length of the discovered item")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("item_mergechain_unlocked_length")]
        public int ItemMergeChainUnlockedLength { get; set; }

        public AnalyticsEventItemDiscovered(string itemName, int itemLevel, int itemMergeChainTotalLength, int itemMergeChainUnlockedLength)
        {
        }
    }
}