using Metaplay.Core.Analytics;
using System.ComponentModel;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;

namespace Analytics
{
    [AnalyticsEvent(3042, "Seasonal event completed", 1, null, false, false, true)]
    public class TriggerEventSeasonalEventCompleted : PlayerTriggerEvent
    {
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("event_id")]
        [Description("Completed seasonal event")]
        public EventId EventId { get; set; }

        public TriggerEventSeasonalEventCompleted()
        {
        }

        public TriggerEventSeasonalEventCompleted(EventId eventId)
        {
        }
    }
}