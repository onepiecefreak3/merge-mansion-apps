using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.Model;
using System;

namespace Analytics
{
    [AnalyticsEvent(154, "Player interaction with Social Media popup", 1, null, false, true, false)]
    public class AnalyticsEventSocialMediaPopupInteraction : AnalyticsServersideEventBase
    {
        [Description("ConfigKey")]
        [JsonProperty("config_key")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ConfigKey;
        [JsonProperty("interaction")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Interaction type")]
        public string Interaction;
        [Description("Where did the player come from")]
        [JsonProperty("source")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public string Source;
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        public AnalyticsEventSocialMediaPopupInteraction()
        {
        }

        public AnalyticsEventSocialMediaPopupInteraction(string configKey, string interaction, string source)
        {
        }
    }
}