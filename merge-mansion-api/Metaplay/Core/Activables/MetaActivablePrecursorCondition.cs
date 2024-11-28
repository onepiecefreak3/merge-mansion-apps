using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace Metaplay.Core.Activables
{
    [MetaSerializable]
    public abstract class MetaActivablePrecursorCondition<TId> : PlayerCondition
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public TId Id { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool Consumed { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaDuration Delay { get; set; }

        public MetaActivablePrecursorCondition()
        {
        }

        public MetaActivablePrecursorCondition(TId id, bool consumed, MetaDuration delay)
        {
        }
    }
}