using Metaplay.Core.Activables;
using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    [MetaActivableSet("ShopEvent", false)]
    [MetaSerializableDerived(3)]
    public class PlayerShopEventsModel : ExtendableEventSet<EventId, ShopEventInfo, ShopEventModel>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<StaleExtensionPurchaseInfo> StaleExtensionPurchaseInfos;
        public PlayerShopEventsModel()
        {
        }
    }
}