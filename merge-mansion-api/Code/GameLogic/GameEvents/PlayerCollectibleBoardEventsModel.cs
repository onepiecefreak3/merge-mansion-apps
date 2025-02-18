using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    [MetaActivableSet("CollectibleBoardEvent", false)]
    [MetaSerializableDerived(8)]
    public class PlayerCollectibleBoardEventsModel : ExtendableEventSet<CollectibleBoardEventId, CollectibleBoardEventInfo, CollectibleBoardEventModel>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<StaleCollectibleBoardEventExtensionPurchaseInfo> StaleExtensionPurchaseInfos;
        public PlayerCollectibleBoardEventsModel()
        {
        }
    }
}