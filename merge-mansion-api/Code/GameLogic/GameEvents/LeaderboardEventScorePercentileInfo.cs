using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class LeaderboardEventScorePercentileInfo : IGameConfigData<int>, IGameConfigData, IHasGameConfigKey<int>, IEventScorePercentileInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Percentile { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Score { get; set; }
        public int ConfigKey { get; }

        public LeaderboardEventScorePercentileInfo()
        {
        }

        public LeaderboardEventScorePercentileInfo(int percentile, int score)
        {
        }
    }
}