using Metaplay.Core.Analytics;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using GameLogic;

namespace Analytics
{
    [AnalyticsEvent(3044, "Hotspot completed", 1, null, false, false, true)]
    public class TriggerEventHotspotCompleted : PlayerTriggerEvent
    {
        [Description("Completed hotspot")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("hotspot_id")]
        public HotspotId HotspotId { get; set; }

        private TriggerEventHotspotCompleted()
        {
        }

        public TriggerEventHotspotCompleted(HotspotId hotspotId)
        {
        }
    }
}