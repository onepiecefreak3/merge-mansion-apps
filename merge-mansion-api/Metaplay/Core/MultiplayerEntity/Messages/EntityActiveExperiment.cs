using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace Metaplay.Core.MultiplayerEntity.Messages
{
    [MetaSerializable]
    public struct EntityActiveExperiment
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public PlayerExperimentId ExperimentId; // 0x0
        [MetaMember(2, (MetaMemberFlags)0)]
        public ExperimentVariantId VariantId; // 0x8
        [MetaMember(3, (MetaMemberFlags)0)]
        public string ExperimentAnalyticsId; // 0x10
        [MetaMember(4, (MetaMemberFlags)0)]
        public string VariantAnalyticsId; // 0x18
        public EntityActiveExperiment(PlayerExperimentId experimentId, ExperimentVariantId variantId, string experimentAnalyticsId, string variantAnalyticsId)
        {
            ExperimentId = experimentId;
            VariantId = variantId;
            ExperimentAnalyticsId = experimentAnalyticsId;
            VariantAnalyticsId = variantAnalyticsId;
        }
    }
}