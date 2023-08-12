using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace Analytics
{
    [AnalyticsEvent(170, "Daily Task refresh purchase", 1, null, true, true, false)]
    public class AnalyticsDailyTasksRefreshPurchase : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("refresh_purchase_count")]
        [Description("Number of times the daily tasks refresh was purchased")]
        public int RefreshPurchasesCount { get; set; }
        public override string EventDescription { get; }

        public AnalyticsDailyTasksRefreshPurchase()
        {
        }

        public AnalyticsDailyTasksRefreshPurchase(int refreshPurchasesCount)
        {
        }
    }
}