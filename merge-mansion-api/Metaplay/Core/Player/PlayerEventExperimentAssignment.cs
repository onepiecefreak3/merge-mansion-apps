using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Player
{
    [AnalyticsEvent(1009, "Assigned into an Experiment", 1, "Player has been assigned into an Experiment. The event contents describe the experiment and the variant in it.", true, true, false)]
    public class PlayerEventExperimentAssignment : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public PlayerEventExperimentAssignment.ChangeSource Source { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string ExperimentId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string VariantId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string ExperimentAnalyticsId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string VariantAnalyticsId { get; set; }
        public override string EventDescription { get; }

        private PlayerEventExperimentAssignment()
        {
        }

        public PlayerEventExperimentAssignment(PlayerEventExperimentAssignment.ChangeSource source, PlayerExperimentId experimentId, ExperimentVariantId variantId, string experimentAnalyticsId, string variantAnalyticsId)
        {
        }

        [MetaSerializable]
        public enum ChangeSource
        {
            AutomaticAssign = 0,
            Admin = 1
        }
    }
}