using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Debugging
{
    [MetaSerializable]
    public class UnityPlatformInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string BuildGuid { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string Platform { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string InternetReachability { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public bool IsEditor { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string ApplicationVersion { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string UnityVersion { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public string SystemLanguage { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public string InstallMode { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public bool IsGenuine { get; set; }

        [MetaMember(100, (MetaMemberFlags)0)]
        public string CommitId { get; set; }

        public UnityPlatformInfo()
        {
        }

        private MetaTime _nextReachabilityUpdateAt;
    }
}