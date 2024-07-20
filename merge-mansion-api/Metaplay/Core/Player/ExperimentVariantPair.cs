using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public struct ExperimentVariantPair
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public PlayerExperimentId ExperimentId; // 0x0
        [MetaMember(2, (MetaMemberFlags)0)]
        public ExperimentVariantId VariantId; // 0x8
        public ExperimentVariantPair(PlayerExperimentId experimentId, ExperimentVariantId variantId)
        {
            ExperimentId = experimentId;
            VariantId = variantId;
        }
    }
}