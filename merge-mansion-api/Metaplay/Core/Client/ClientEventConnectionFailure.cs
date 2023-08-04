using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Client
{
    [AnalyticsEvent(1902, "Connection Failure", 1, "Client-only event! Client failed to connect to the server, or an existing connection was lost. This can occur for a number of reasons, described by the event parameters.", true, true, false)]
    public class ClientEventConnectionFailure : ClientEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string TechnicalErrorString { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string ExtraTechnicalInfo { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int TechnicalErrorCode { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string PlayerFacingReason { get; set; }

        private ClientEventConnectionFailure()
        {
        }

        public ClientEventConnectionFailure(string technicalErrorString, string extraTechnicalInfo, int technicalErrorCode, string playerFacingReason)
        {
        }
    }
}