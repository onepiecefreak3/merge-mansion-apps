using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Activables;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(2)]
    [MetaSerializable]
    public class EventShopOfferPrecursorCondition : MetaActivablePrecursorCondition<EventOfferId>
    {
        [MetaMember(4, 0)]
        public EventId ShopEventId { get; set; }
    }
}
