using GameLogic.Player.Items.Production;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Decay
{
    [MetaSerializable]
    public class DecayFeatures
    {
        [MetaMember(1)]
        public bool DoesDecay { get; set; }
        [MetaMember(2)]
        public MetaDuration Lifetime { get; set; }
        [MetaMember(3)]
        public IItemProducer ItemProducer { get; set; }
        [MetaMember(4)]
        public DecayMergeMode DecayMergeMode { get; set; }
        [MetaMember(5)]
        public bool DoesBoosterAccelerateDecay { get; set; }
        [MetaMember(6)]
        public DecayInheritMode DecayInheritMode { get; set; }
	}
}
