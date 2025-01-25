using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(8)]
    [MetaActivableSet("SideBoardEvent", false)]
    public class PlayerSideBoardEventsModel : ExtendableEventSet<SideBoardEventId, SideBoardEventInfo, SideBoardEventModel>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<StaleSideBoardEventExtensionPurchaseInfo> StaleExtensionPurchaseInfos;
        public PlayerSideBoardEventsModel()
        {
        }
    }
}