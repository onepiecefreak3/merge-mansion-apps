using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;
using Code.GameLogic.GameEvents;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1039)]
    public class PlayerLevelInSideBoardEvent : TypedPlayerPropertyId<int>
    {
        private static int InvalidResult;
        [MetaMember(1, (MetaMemberFlags)0)]
        private SideBoardEventId EventId { get; set; }
        public override string DisplayName { get; }

        public PlayerLevelInSideBoardEvent()
        {
        }

        public PlayerLevelInSideBoardEvent(SideBoardEventId eventId)
        {
        }
    }
}