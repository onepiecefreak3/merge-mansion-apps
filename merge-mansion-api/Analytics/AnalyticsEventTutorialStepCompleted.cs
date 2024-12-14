using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using System;

namespace Analytics
{
    [AnalyticsEvent(110, "Tutorial step completed", 1, null, false, true, false)]
    public class AnalyticsEventTutorialStepCompleted : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Id of the tutorial step that was completed")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("id")]
        public string Id { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventTutorialStepCompleted()
        {
        }

        public AnalyticsEventTutorialStepCompleted(string id)
        {
        }
    }
}