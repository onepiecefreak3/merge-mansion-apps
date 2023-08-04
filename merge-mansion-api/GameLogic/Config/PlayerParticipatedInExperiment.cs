using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;
using System.Runtime.Serialization;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1023)]
    public class PlayerParticipatedInExperiment : TypedPlayerPropertyId<bool>
    {
        private static string ControlVariant;
        public override string DisplayName { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        private PlayerExperimentId Experiment { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private ExperimentVariantId VariantId { get; set; }

        [IgnoreDataMember]
        private bool MatchesControl { get; }

        private PlayerParticipatedInExperiment()
        {
        }

        public PlayerParticipatedInExperiment(PlayerExperimentId experiment, ExperimentVariantId variantId)
        {
        }
    }
}