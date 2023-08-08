using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Leaderboard
{
    [MetaSerializable]
    public class LeaderBoardScoreEntry
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string Name { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Score { get; set; }

        private LeaderBoardScoreEntry()
        {
        }

        public LeaderBoardScoreEntry(string name, int score)
        {
        }
    }
}