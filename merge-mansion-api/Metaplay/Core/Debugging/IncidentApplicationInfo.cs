using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Debugging
{
    [MetaSerializable]
    public class IncidentApplicationInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public BuildVersion BuildVersion { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DeviceGuid { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string ActiveLanguage { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int HighestSupportedLogicVersion { get; set; }

        private IncidentApplicationInfo()
        {
        }

        public IncidentApplicationInfo(BuildVersion buildVersion, string deviceGuid, string activeLanguage, int highestSupportedLogicVersion)
        {
        }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string EnvironmentId { get; set; }

        public IncidentApplicationInfo(BuildVersion buildVersion, string deviceGuid, string activeLanguage, int highestSupportedLogicVersion, string environmentId)
        {
        }
    }
}