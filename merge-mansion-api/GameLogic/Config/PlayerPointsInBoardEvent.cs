using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1030)]
    [MetaSerializable]
    public class PlayerPointsInBoardEvent : TypedPlayerPropertyId<int>
    {
        [MetaMember(1, 0)]
        private EventId EventId { get; set; }

        private static int InvalidResult;
        public override string DisplayName { get; }

        public PlayerPointsInBoardEvent()
        {
        }

        public PlayerPointsInBoardEvent(EventId eventIdId)
        {
        }
    }
}