using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Player
{
    [AnalyticsEvent(1019, "Crashed", 1, "The PlayerActor has crashed.", true, true, false)]
    public class PlayerEventActorCrashed : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ErrorType { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string ErrorMessage { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string StackTrace { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string IncidentId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string IncidentFingerprint { get; set; }
        public override string EventDescription { get; }

        public PlayerEventActorCrashed()
        {
        }

        public PlayerEventActorCrashed(string errorType, string errorMessage, string stackTrace, string incidentId, string incidentFingerprint)
        {
        }
    }
}