using Metaplay.Core.Model;

namespace Metaplay.Core
{
    [MetaSerializable]
    public struct BuildVersion
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public readonly string Version; // 0x0
        [MetaMember(2, (MetaMemberFlags)0)]
        public readonly string BuildNumber; // 0x8
        [MetaMember(3, (MetaMemberFlags)0)]
        public readonly string CommitId; // 0x10
        public BuildVersion(string version, string buildNumber, string commitId)
        {
            Version = version;
            BuildNumber = buildNumber;
            CommitId = commitId;
        }
    }
}