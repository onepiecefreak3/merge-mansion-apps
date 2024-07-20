using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System;

namespace Analytics
{
    [AnalyticsEvent(169, "Bot session end", 1, null, true, true, false)]
    public class AnalyticsEventBotSessionEnd : AnalyticsServersideEventBase
    {
        [JsonProperty("bot_session_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public int SessionId;
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("bot_configuration_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ConfigId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventBotSessionEnd()
        {
        }

        public AnalyticsEventBotSessionEnd(string configurationId, int sessionId)
        {
        }
    }
}