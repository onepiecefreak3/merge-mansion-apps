using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.TheGreatEscape
{
    [MetaSerializable]
    public class MinigameActivationFeatures
    {
        public static MinigameActivationFeatures NoMinigameActivationFeatures;
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsMinigameActivation { get; set; }

        private MinigameActivationFeatures()
        {
        }

        public MinigameActivationFeatures(bool isMinigameActivation)
        {
        }
    }
}