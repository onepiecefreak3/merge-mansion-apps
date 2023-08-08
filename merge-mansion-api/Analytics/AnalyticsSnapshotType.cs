using Metaplay.Core.Model;

namespace Analytics
{
    [MetaSerializable]
    public enum AnalyticsSnapshotType
    {
        SessionStart = 0,
        SessionEnd = 1,
        InSession = 2
    }
}