using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace Metaplay.Core.LiveOpsEvent
{
    [ModelAction(10305)]
    public class PlayerAbruptlyRemoveLiveOpsEvent : PlayerActionCore<IPlayerModelBase>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaGuid EventId { get; set; }

        private PlayerAbruptlyRemoveLiveOpsEvent()
        {
        }

        public PlayerAbruptlyRemoveLiveOpsEvent(MetaGuid eventId)
        {
        }
    }
}