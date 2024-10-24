using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace GameLogic.Player.Leaderboard.BoultonLeague
{
    [MetaSerializable]
    public class BoultonLeagueDivisionParticipantSnapshot
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int ParticipantIndex { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Score { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public Dictionary<int, int> FinishedCountPerStageNumber { get; set; }

        private BoultonLeagueDivisionParticipantSnapshot()
        {
        }

        public BoultonLeagueDivisionParticipantSnapshot(int participantIndex, int score, string displayName, Dictionary<int, int> finishedCountPerStageNumber)
        {
        }
    }
}