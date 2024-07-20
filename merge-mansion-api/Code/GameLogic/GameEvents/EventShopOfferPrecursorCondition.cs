using Metaplay.Core.Activables;
using Metaplay.Core.Model;
using System;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(2)]
    public class EventShopOfferPrecursorCondition : MetaActivablePrecursorCondition<EventOfferId>
    {
        [MetaMember(4, (MetaMemberFlags)0)]
        public EventId ShopEventId { get; set; }

        private EventShopOfferPrecursorCondition()
        {
        }

        public EventShopOfferPrecursorCondition(EventId shopEventId, EventOfferId id, bool consumed, MetaDuration delay)
        {
        }
    }
}