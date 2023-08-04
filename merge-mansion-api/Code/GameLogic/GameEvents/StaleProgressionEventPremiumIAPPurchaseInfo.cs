using Metaplay.Core.Model;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class StaleProgressionEventPremiumIAPPurchaseInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ProgressionEventId EventId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime ClaimTime;
        private StaleProgressionEventPremiumIAPPurchaseInfo()
        {
        }

        public StaleProgressionEventPremiumIAPPurchaseInfo(ProgressionEventId eventId, MetaTime claimTime)
        {
        }
    }
}