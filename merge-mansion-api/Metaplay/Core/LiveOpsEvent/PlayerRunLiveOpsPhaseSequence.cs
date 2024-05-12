using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System.Collections.Generic;

namespace Metaplay.Core.LiveOpsEvent
{
    [ModelAction(10301)]
    public class PlayerRunLiveOpsPhaseSequence : PlayerSynchronizedServerActionCore<IPlayerModelBase>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaGuid EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<LiveOpsEventPhase> FastForwardedPhases { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public LiveOpsEventPhase NewPhase { get; set; }

        private PlayerRunLiveOpsPhaseSequence()
        {
        }

        public PlayerRunLiveOpsPhaseSequence(MetaGuid eventId, List<LiveOpsEventPhase> fastForwardedPhases, LiveOpsEventPhase newPhase)
        {
        }
    }
}