using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using System;
using GameLogic;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 3 })]
    [AnalyticsEvent(174, "Rentable inventory purchased", 1, null, true, true, false)]
    public class AnalyticsEventRentableInventoryBatchPurchased : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Batch cost")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("batch_cost")]
        public long Cost { get; set; }

        [Description("Batch currency")]
        [JsonProperty("batch_currency")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public Currencies Currency { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventRentableInventoryBatchPurchased()
        {
        }

        public AnalyticsEventRentableInventoryBatchPurchased(long cost, Currencies currency)
        {
        }
    }
}