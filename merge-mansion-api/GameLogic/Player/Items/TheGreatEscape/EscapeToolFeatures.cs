using Metaplay.Core.Model;
using System;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Items.TheGreatEscape
{
    [MetaSerializable]
    public class EscapeToolFeatures
    {
        public static EscapeToolFeatures NoEscapeToolFeatures;
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsEscapeTool { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public TheGreatEscapeMinigameId MinigameId { get; set; }

        private EscapeToolFeatures()
        {
        }

        public EscapeToolFeatures(bool isEscapeTool, TheGreatEscapeMinigameId minigameId)
        {
        }
    }
}