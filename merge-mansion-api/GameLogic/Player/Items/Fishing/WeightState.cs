using Metaplay.Core.Model;
using Metaplay.Core.Math;

namespace GameLogic.Player.Items.Fishing
{
    [MetaSerializable]
    public class WeightState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public F32 Weight { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public WeightCategory WeightCategory { get; set; }

        private WeightState()
        {
        }

        public WeightState(F32 weight, WeightCategory weightCategory)
        {
        }
    }
}