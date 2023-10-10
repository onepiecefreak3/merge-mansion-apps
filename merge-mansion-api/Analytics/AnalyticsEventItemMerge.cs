using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [AnalyticsEvent(103, "Item merge", 1, null, false, true, false)]
    public class AnalyticsEventItemMerge : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Item that has been merge")]
        [JsonProperty("item_name")]
        public string MergedItem { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventItemMerge()
        {
        }

        public AnalyticsEventItemMerge(string itemType)
        {
        }

        [Description("Merged item level")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("item_level")]
        public int MergedItemLevel { get; set; }

        [Description("Merge chain total length of the merged item")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("item_mergechain_total_length")]
        public int MergedItemMergeChainTotalLength { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("item_mergechain_unlocked_length")]
        [Description("Merge chain unlocked length of the merged item")]
        public int MergedItemMergeChainUnlockedLength { get; set; }

        public AnalyticsEventItemMerge(string itemType, int itemLevel, int itemMergeChainTotalLength, int itemMergeChainUnlockedLength)
        {
        }
    }
}