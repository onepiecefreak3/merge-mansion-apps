using Metaplay.Core.Model;
using System;
using GameLogic.Player.Rewards;

namespace GameLogic.Player.Items.Fishing
{
    [MetaSerializable]
    public class PrisonLetterState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsEscapeTool { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public PlayerReward LetterReward { get; set; }

        private PrisonLetterState()
        {
        }

        public PrisonLetterState(bool isEscapeTool, PlayerReward letterReward)
        {
        }
    }
}