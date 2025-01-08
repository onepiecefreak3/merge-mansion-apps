using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System;

namespace Analytics
{
    [AnalyticsEvent(168, "Bot session start", 1, null, true, true, false)]
    public class AnalyticsEventBotSessionStart : AnalyticsServersideEventBase
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("bot_session_id")]
        public int SessionId;
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("bot_configuration_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ConfigId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventBotSessionStart()
        {
        }

        public AnalyticsEventBotSessionStart(string configurationId, int sessionId)
        {
        }
    }
}