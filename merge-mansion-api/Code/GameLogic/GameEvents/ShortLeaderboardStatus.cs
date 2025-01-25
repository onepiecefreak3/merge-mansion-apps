using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class ShortLeaderboardStatus
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int Rank { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public ShortLeaderboardStatus.WinState State { get; set; }

        public ShortLeaderboardStatus()
        {
        }

        [MetaSerializable]
        public enum WinState
        {
            Initial = 0,
            Win = 1,
            Normal = 2,
            Lose = 3
        }
    }
}