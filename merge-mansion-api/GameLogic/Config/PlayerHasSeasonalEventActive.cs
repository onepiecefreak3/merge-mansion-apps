using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;
using Code.GameLogic.GameEvents;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1018)]
    public class PlayerHasSeasonalEventActive : TypedPlayerPropertyId<bool>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private EventId RequiredEvent { get; set; }
        public override string DisplayName { get; }

        public PlayerHasSeasonalEventActive()
        {
        }

        public PlayerHasSeasonalEventActive(EventId requiredEvent)
        {
        }
    }
}