using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1032)]
    public class PlayerPointsInCollectibleBoardEvent : TypedPlayerPropertyId<int>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private CollectibleBoardEventId EventId { get; set; }

        private static int InvalidResult;
        public override string DisplayName { get; }

        public PlayerPointsInCollectibleBoardEvent()
        {
        }

        public PlayerPointsInCollectibleBoardEvent(CollectibleBoardEventId eventId)
        {
        }
    }
}