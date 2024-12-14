using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Fishing
{
    [MetaSerializable]
    public class MinigameActivationState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsMinigameActivation { get; set; }

        private MinigameActivationState()
        {
        }

        public MinigameActivationState(bool isMinigameActivation)
        {
        }
    }
}