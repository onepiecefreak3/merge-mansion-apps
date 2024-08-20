using Metaplay.Core.Model;
using System.Collections.Generic;
using Metaplay.Core.Math;

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
    }
}