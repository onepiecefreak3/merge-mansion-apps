using System;

namespace Code.GameLogic.GameEvents
{
    public interface IEventScorePercentileInfo
    {
        int Percentile { get; }

        int Score { get; }
    }
}