using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1031)]
    [MetaSerializable]
    public class PlayerPointsInProgressionEvent : TypedPlayerPropertyId<int>
    {
        [MetaMember(1, 0)]
        private ProgressionEventId Event { get; set; }

        private static int InvalidResult;
        public override string DisplayName { get; }

        public PlayerPointsInProgressionEvent()
        {
        }

        public PlayerPointsInProgressionEvent(ProgressionEventId eventId)
        {
        }
    }
}