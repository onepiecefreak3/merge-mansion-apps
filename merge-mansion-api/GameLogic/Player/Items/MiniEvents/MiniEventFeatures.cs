using Metaplay.Core.Model;
using System.Collections.Generic;
using Metaplay.Core.Math;
using System;
using Metaplay.Core;

namespace GameLogic.Player.Items.MiniEvents
{
    [MetaSerializable]
    public class MiniEventFeatures
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private List<F64?> ProducerTimeSkipPrice { get; set; }
        public static MiniEventFeatures NoMiniEventFeatures { get; }

        private MiniEventFeatures()
        {
        }

        public MiniEventFeatures(List<F64?> producerTimeSkipPrice)
        {
        }

        [MetaMember(2, (MetaMemberFlags)0)]
        private List<int?> ProducerCapacity { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private List<MetaDuration?> ProducerTimer { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private List<int?> BubblePrice { get; set; }

        public MiniEventFeatures(List<F64?> producerTimeSkipPrice, List<int?> producerCapacity, List<MetaDuration?> producerTimer, List<int?> bubblePrice)
        {
        }
    }
}