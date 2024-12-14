using Metaplay.Core.Model;
using System;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Items.Fishing
{
    [MetaSerializable]
    public class EscapeToolState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsEscapeTool { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public TheGreatEscapeMinigameId MinigameId { get; set; }

        private EscapeToolState()
        {
        }

        public EscapeToolState(bool isEscapeTool, TheGreatEscapeMinigameId minigameId)
        {
        }
    }
}