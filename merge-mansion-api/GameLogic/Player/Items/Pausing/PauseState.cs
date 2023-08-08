using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Pausing
{
    [MetaSerializable]
    public class PauseState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool DecayPaused { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool ActivationPaused { get; set; }

        public PauseState()
        {
        }
    }
}