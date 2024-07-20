using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializable]
    [MetaBlockedMembers(new int[] { 3 })]
    public class SinkFeatures
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsSink { get; set; }

        [MetaMember(2, 0)]
        public ISinkStateFactory Factory { get; set; }

        public static SinkFeatures NoSink;
        private SinkFeatures()
        {
        }

        public SinkFeatures(bool isSinkItem, ISinkStateFactory sinkStateFactory, string overrideSfx)
        {
        }

        [MetaMember(4, (MetaMemberFlags)0)]
        public bool HideProgressBar { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool HideUndiscoveredItemsInHints { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public bool AllowReverseSinking { get; set; }

        public SinkFeatures(bool isSinkItem, ISinkStateFactory sinkStateFactory, bool hideProgressBar, bool hideUndiscoveredItemsInHints, bool allowReverseSinking)
        {
        }
    }
}