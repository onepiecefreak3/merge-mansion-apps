using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public enum BoultonLeagueEventScoreSourceType
    {
        None = 0,
        Debug = 1,
        HotspotCompletion = 2,
        Reward = 3
    }
}