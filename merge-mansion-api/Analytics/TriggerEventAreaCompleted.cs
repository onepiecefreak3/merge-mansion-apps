using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using GameLogic.Area;

namespace Analytics
{
    [AnalyticsEvent(3043, "Area completed", 1, null, false, false, true)]
    public class TriggerEventAreaCompleted : PlayerTriggerEvent
    {
        [JsonProperty("area_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [Description("Completed area")]
        public AreaId AreaId { get; set; }

        private TriggerEventAreaCompleted()
        {
        }

        public TriggerEventAreaCompleted(AreaId areaId)
        {
        }
    }
}