using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public enum BoultonLeagueMatchmakingAlgorithm
    {
        BoultonLeagueEventScorePercentile = 0,
        LeaderboardEventScorePercentile = 1
    }
}