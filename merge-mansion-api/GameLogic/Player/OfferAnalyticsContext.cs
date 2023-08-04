using Metaplay.Core.Model;
using System;

namespace GameLogic.Player
{
    [MetaSerializableDerived(4)]
    public class OfferAnalyticsContext : AnalyticsContext
    {
        [MetaMember(10, (MetaMemberFlags)0)]
        public int SlotId { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public string ImpressionId { get; set; }

        public OfferAnalyticsContext()
        {
        }

        public OfferAnalyticsContext(string context, string target, int slotId, string impressionId)
        {
        }
    }
}