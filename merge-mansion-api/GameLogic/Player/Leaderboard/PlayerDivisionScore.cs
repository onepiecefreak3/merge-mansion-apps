using Metaplay.Core.Model;
using Metaplay.Core.League;
using System;
using Metaplay.Core;

namespace GameLogic.Player.Leaderboard
{
    [MetaSerializableDerived(1)]
    public class PlayerDivisionScore : IDivisionScore, IDivisionContribution
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Points;
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime LastActionAt;
        public PlayerDivisionScore()
        {
        }
    }
}