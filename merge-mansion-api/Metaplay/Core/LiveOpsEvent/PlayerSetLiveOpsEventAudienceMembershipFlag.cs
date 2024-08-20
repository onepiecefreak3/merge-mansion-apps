using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace Metaplay.Core.LiveOpsEvent
{
    [ModelAction(10307)]
    public class PlayerSetLiveOpsEventAudienceMembershipFlag : PlayerSynchronizedServerActionCore<IPlayerModelBase>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaGuid EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool PlayerIsInTargetAudience { get; set; }

        private PlayerSetLiveOpsEventAudienceMembershipFlag()
        {
        }

        public PlayerSetLiveOpsEventAudienceMembershipFlag(MetaGuid eventId, bool playerIsInTargetAudience)
        {
        }
    }
}