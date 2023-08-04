using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Player
{
    [AnalyticsEvent(1018, "Incident Recorded", 1, "A player incident occurred. In addition to this event, incidents produce more detailed reports which can be viewed in the LiveOps Dashboard.", true, true, false)]
    public class PlayerEventIncidentRecorded : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string IncidentId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime OccurredAt { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Type { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string SubType { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string Reason { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string Fingerprint { get; set; }
        public override string EventDescription { get; }

        private PlayerEventIncidentRecorded()
        {
        }

        public PlayerEventIncidentRecorded(string incidentId, MetaTime occurredAt, string type, string subType, string reason, string fingerprint)
        {
        }
    }
}