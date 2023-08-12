using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace GameLogic.Player.Items.Sinkable
{
    [MetaSerializable]
    public class SinkableFeatures
    {
        public static SinkableFeatures NoSinkableFeatures;
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsSinkable { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<ISinkInAction> SinkInActions { get; set; }

        private SinkableFeatures()
        {
        }

        public SinkableFeatures(bool isSinkable, IEnumerable<ISinkInAction> sinkInActions)
        {
        }
    }
}