using Metaplay.Core.MultiplayerEntity.Messages;

namespace Metaplay.Core.Player
{
    public readonly struct ExperimentMembershipStatus // TypeDefIndex: 466
    {
        // Fields
        public readonly PlayerExperimentId ExperimentId; // 0x0
        public readonly string ExperimentAnalyticsId; // 0x8
        public readonly ExperimentVariantId VariantId; // 0x10
        public readonly string VariantAnalyticsId; // 0x18

        // Properties
        public bool IsInControlGroup => VariantId == null;

        // RVA: 0x20686C4 Offset: 0x20686C4 VA: 0x20686C4
        private ExperimentMembershipStatus(PlayerExperimentId experimentId, string experimentAnalyticsId,
            ExperimentVariantId variantId, string variantAnalyticsId)
        {
            ExperimentId = experimentId;
            ExperimentAnalyticsId = experimentAnalyticsId;
            VariantId = variantId;
            VariantAnalyticsId = variantAnalyticsId;
        }

        // RVA: 0x20686D0 Offset: 0x20686D0 VA: 0x20686D0
        public static ExperimentMembershipStatus FromSessionInfo(EntityActiveExperiment sessionExperiment)
        {
            return new ExperimentMembershipStatus(sessionExperiment.ExperimentId, sessionExperiment.ExperimentAnalyticsId, sessionExperiment.VariantId, sessionExperiment.VariantAnalyticsId);
        }
    }
}
