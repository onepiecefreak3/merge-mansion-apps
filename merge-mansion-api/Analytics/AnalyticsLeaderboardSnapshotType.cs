using Metaplay.Core.Model;

namespace Analytics
{
    [MetaSerializable]
    public enum AnalyticsLeaderboardSnapshotType
    {
        Created = 0,
        SessionStart = 1,
        InSession = 2,
        Finalized = 3,
        PlayerJoined = 4
    }
}