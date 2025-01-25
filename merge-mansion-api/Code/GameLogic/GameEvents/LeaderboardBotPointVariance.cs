using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class LeaderboardBotPointVariance
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int MinPoints { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int MaxPoints { get; set; }

        public LeaderboardBotPointVariance()
        {
        }

        public LeaderboardBotPointVariance(int minPoints, int maxPoints)
        {
        }
    }
}