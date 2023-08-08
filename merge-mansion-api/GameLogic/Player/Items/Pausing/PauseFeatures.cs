using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Pausing
{
    [MetaSerializable]
    public class PauseFeatures
    {
        public static PauseFeatures NoPause;
        public static PauseFeatures OnlyDecayCanBePaused;
        public static PauseFeatures OnlyActivationCanBePaused;
        public static PauseFeatures BoosterWithPause;
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool SupportsPause { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool DecayCanBePaused { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public bool ActivationCanBePaused { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public bool BoostingCanBePaused { get; set; }

        public PauseFeatures()
        {
        }
    }
}