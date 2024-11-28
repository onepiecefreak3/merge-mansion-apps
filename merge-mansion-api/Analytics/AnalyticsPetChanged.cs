using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.Model;
using System;

namespace Analytics
{
    [AnalyticsEvent(179, "Pet has been changed", 1, null, false, true, false)]
    public class AnalyticsPetChanged : AnalyticsServersideEventBase
    {
        [JsonProperty("pet_id_prev")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Previous pet (null if there was nothing)")]
        public string PreviousPetId;
        [Description("New pet (null if slot was cleared)")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("pet_id_new")]
        public string NewPetId;
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        public AnalyticsPetChanged()
        {
        }
    }
}