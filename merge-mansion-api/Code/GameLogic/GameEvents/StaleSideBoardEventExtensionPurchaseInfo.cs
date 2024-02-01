using Metaplay.Core.Model;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class StaleSideBoardEventExtensionPurchaseInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public SideBoardEventId EventId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime ClaimTime;
        private StaleSideBoardEventExtensionPurchaseInfo()
        {
        }

        public StaleSideBoardEventExtensionPurchaseInfo(SideBoardEventId eventId, MetaTime claimTime)
        {
        }
    }
}