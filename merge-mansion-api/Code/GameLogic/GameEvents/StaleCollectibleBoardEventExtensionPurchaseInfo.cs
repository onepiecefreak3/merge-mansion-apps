using Metaplay.Core.Model;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class StaleCollectibleBoardEventExtensionPurchaseInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CollectibleBoardEventId EventId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime ClaimTime;
        private StaleCollectibleBoardEventExtensionPurchaseInfo()
        {
        }

        public StaleCollectibleBoardEventExtensionPurchaseInfo(CollectibleBoardEventId eventId, MetaTime claimTime)
        {
        }
    }
}