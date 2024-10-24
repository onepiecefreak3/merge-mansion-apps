using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class BoultonLeagueRankInfo : IGameConfigData<int>, IGameConfigData, IHasGameConfigKey<int>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Rank { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int StageNumber { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int DivisionSize { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int ScorePercentileRangeMin { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int ScorePercentileRangeMax { get; set; }
        public int ConfigKey { get; }

        public BoultonLeagueRankInfo()
        {
        }

        public BoultonLeagueRankInfo(int rank, int stageNumber, int divisionSize, int scorePercentileRangeMin, int scorePercentileRangeMax)
        {
        }
    }
}