using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using Metaplay.Core.Player;

namespace Analytics
{
    [AnalyticsEvent(151, "Player deleted", 1, null, false, true, false)]
    public class AnalyticsEventPlayerDeleted : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("scheduled")]
        [Description("Scheduled?")]
        public bool Scheduled { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("status")]
        [Description("Deletion status")]
        public PlayerDeletionStatus DeletionStatus { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventPlayerDeleted()
        {
        }

        public AnalyticsEventPlayerDeleted(bool scheduled, PlayerDeletionStatus status)
        {
        }
    }
}