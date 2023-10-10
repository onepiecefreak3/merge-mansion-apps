using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public class PlayerExperimentInfo : IGameConfigData<PlayerExperimentId>, IGameConfigData, IGameConfigKey<PlayerExperimentId>, IGameConfigPostLoad
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public PlayerExperimentId ExperimentId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public string Description { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public Dictionary<ExperimentVariantId, PlayerExperimentInfo.Variant> Variants { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public string ExperimentAnalyticsId { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public string ControlVariantAnalyticsId { get; set; }
        public List<ExperimentVariantId> VariantId { get; set; }
        public List<string> VariantAnalyticsId { get; set; }

        public PlayerExperimentId ConfigKey { get; }

        public PlayerExperimentInfo()
        {
        }

        [MetaSerializable]
        public class Variant
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public ExperimentVariantId Id { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public string AnalyticsId { get; set; }
            public FullGameConfigPatch ConfigPatch { get; set; }

            private Variant()
            {
            }

            public Variant(ExperimentVariantId id, string analyticsId)
            {
            }
        }
    }
}