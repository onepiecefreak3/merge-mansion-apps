using Metaplay.Core.Activables;
using Metaplay.Core.Model;
using GameLogic.ProgressivePacks;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(20)]
    [MetaActivableSet("ProgressionPackEvent", false)]
    public class ProgressionPackEventsModel : MetaActivableSet<ProgressionPackEventId, ProgressionPackEventInfo, ProgressionPackEventModel>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<StaleEventPremiumIAPPurchaseInfo> StalePremiumIAPPurchaseInfos;
        public ProgressionPackEventsModel()
        {
        }
    }
}