using Metaplay.Core.Model;
using System.Collections.Generic;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class ActivationConfig
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Dictionary<CardHiddenRarity, HiddenRarityConfig> ConfigByHiddenRarity { get; set; }

        private ActivationConfig()
        {
        }

        public ActivationConfig(Dictionary<CardHiddenRarity, HiddenRarityConfig> configByHiddenRarity)
        {
        }
    }
}