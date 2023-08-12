using Metaplay.Core.Model;
using System;
using Metaplay.Core.Math;

namespace GameLogic.Player.Items.Fishing
{
    [MetaSerializable]
    public class FishingRodState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int WaterDropletCount { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Item { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public WeightCategory? WeightCategory { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public F32? Weight { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int TapCount { get; set; }

        private FishingRodState()
        {
        }

        public FishingRodState(int waterDropletCount, int item, WeightCategory? weightCategory, F32? weight)
        {
        }
    }
}