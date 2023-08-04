using Metaplay.Core.Model;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class StaleExtensionPurchaseInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EventId EventId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime ClaimTime;
        private StaleExtensionPurchaseInfo()
        {
        }

        public StaleExtensionPurchaseInfo(EventId eventId, MetaTime claimTime)
        {
        }
    }
}