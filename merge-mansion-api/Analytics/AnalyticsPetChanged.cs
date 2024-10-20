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
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Previous pet (null if there was nothing)")]
        [JsonProperty("pet_id_prev")]
        public string PreviousPetId;
        [Description("New pet (null if slot was cleared)")]
        [JsonProperty("pet_id_new")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string NewPetId;
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        public AnalyticsPetChanged()
        {
        }
    }
}