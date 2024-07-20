using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(2)]
    [MetaActivableSet("BoardEvent", false)]
    public class PlayerBoardEventsModel : ExtendableEventSet<EventId, BoardEventInfo, BoardEventModel>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<StaleExtensionPurchaseInfo> StaleExtensionPurchaseInfos;
        public PlayerBoardEventsModel()
        {
        }
    }
}