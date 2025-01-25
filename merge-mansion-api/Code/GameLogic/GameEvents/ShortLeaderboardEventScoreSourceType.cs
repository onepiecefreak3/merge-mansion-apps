using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public enum ShortLeaderboardEventScoreSourceType
    {
        None = 0,
        Debug = 1,
        HotspotCompletion = 2,
        Reward = 3,
        BotTick = 4,
        BotFastForward = 5
    }
}