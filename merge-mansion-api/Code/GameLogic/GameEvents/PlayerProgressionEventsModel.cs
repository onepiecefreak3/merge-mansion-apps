using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    [MetaActivableSet("ProgressionEvent", false)]
    [MetaSerializableDerived(6)]
    public class PlayerProgressionEventsModel : MetaActivableSet<ProgressionEventId, ProgressionEventInfo, ProgressionEventModel>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<StaleProgressionEventPremiumIAPPurchaseInfo> StalePremiumIAPPurchaseInfos;
        public PlayerProgressionEventsModel()
        {
        }
    }
}