using Metaplay.Core.Model;

namespace Metaplay.Core.League
{
    [MetaSerializable]
    public enum LeagueJoinRefuseReason
    {
        UnknownReason = 0,
        LeagueNotEnabled = 1,
        LeagueNotStarted = 2,
        SeasonMigrationInProgress = 3,
        RequirementsNotMet = 4,
        AlreadyInLeague = 5
    }
}