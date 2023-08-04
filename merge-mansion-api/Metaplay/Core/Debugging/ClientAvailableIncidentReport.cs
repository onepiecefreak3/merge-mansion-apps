using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Debugging
{
    [MetaSerializable]
    public class ClientAvailableIncidentReport
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string IncidentId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string Type { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string SubType { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string Reason { get; set; }

        private ClientAvailableIncidentReport()
        {
        }

        public ClientAvailableIncidentReport(string incidentId, string type, string subType, string reason)
        {
        }
    }
}