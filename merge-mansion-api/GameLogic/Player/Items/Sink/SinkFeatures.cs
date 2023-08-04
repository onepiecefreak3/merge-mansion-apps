using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializable]
    public class SinkFeatures
    {
        [MetaMember(1, 0)]
        public bool IsSink { get; set; }

        [MetaMember(2, 0)]
        public ISinkStateFactory Factory { get; set; }

        [MetaMember(3, 0)]
        public string OverrideSfx { get; set; }

        public static SinkFeatures NoSink;
        private SinkFeatures()
        {
        }

        public SinkFeatures(bool isSinkItem, ISinkStateFactory sinkStateFactory, string overrideSfx)
        {
        }
    }
}