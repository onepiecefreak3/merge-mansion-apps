using Metaplay.Core.Activables;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(2)]
    [MetaSerializable]
    public class EventShopOfferPrecursorCondition : MetaActivablePrecursorCondition<EventOfferId>
    {
        [MetaMember(4, 0)]
        public EventId ShopEventId { get; set; }
    }
}
