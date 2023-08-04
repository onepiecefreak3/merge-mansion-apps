using Metaplay.Core.Model;
using Metaplay.Core.Math;
using Metaplay.Core;

namespace GameLogic.Player.Items.Boosting
{
    [MetaSerializable]
    public class BoosterState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public F32 BoostMultiplier { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime LastCalculationTime { get; set; }

        public BoosterState()
        {
        }

        public BoosterState(F32 boostMultiplier, MetaTime lastCalculationTime)
        {
        }
    }
}