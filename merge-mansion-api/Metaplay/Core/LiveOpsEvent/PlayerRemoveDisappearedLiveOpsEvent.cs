using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace Metaplay.Core.LiveOpsEvent
{
    [ModelAction(10304)]
    public class PlayerRemoveDisappearedLiveOpsEvent : PlayerSynchronizedServerActionCore<IPlayerModelBase>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaGuid EventId { get; set; }

        private PlayerRemoveDisappearedLiveOpsEvent()
        {
        }

        public PlayerRemoveDisappearedLiveOpsEvent(MetaGuid eventId)
        {
        }
    }
}