using Metaplay.Core.Model;
using System;
using Metaplay.Core;
using System.Collections.Generic;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class CollectItemsOnSessionStartSettings
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool Enabled { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaDuration DurationSinceLastSession { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<int> TypesToCollect { get; set; }

        public CollectItemsOnSessionStartSettings()
        {
        }

        public CollectItemsOnSessionStartSettings(bool enabled, MetaDuration durationSinceLastSession, List<int> typesToCollect)
        {
        }
    }
}