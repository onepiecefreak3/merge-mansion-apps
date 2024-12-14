using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [AnalyticsEvent(175, "Bot test start", 1, null, true, true, false)]
    public class AnalyticsEventBotTestStart : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("bot_configuration_id")]
        public string ConfigId { get; set; }

        [JsonProperty("test_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string TestId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventBotTestStart()
        {
        }

        public AnalyticsEventBotTestStart(string configurationId, string testId)
        {
        }
    }
}