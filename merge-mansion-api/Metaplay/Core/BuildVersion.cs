namespace Metaplay.Metaplay.Core
{
    public readonly struct BuildVersion
    {
        public readonly string Version; // 0x0
        public readonly string BuildNumber; // 0x8
        public readonly string CommitId; // 0x10

        public BuildVersion(string version, string buildNumber, string commitId)
        {
            Version = version;
            BuildNumber = buildNumber;
            CommitId = commitId;
        }
    }
}
