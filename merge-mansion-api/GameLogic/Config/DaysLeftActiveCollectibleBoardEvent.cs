using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;
using Code.GameLogic.GameEvents;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1055)]
    public class DaysLeftActiveCollectibleBoardEvent : TypedPlayerPropertyId<int>
    {
        private static int FailIndex;
        [MetaMember(1, (MetaMemberFlags)0)]
        private CollectibleBoardEventId EventId { get; set; }
        public override string DisplayName { get; }

        public DaysLeftActiveCollectibleBoardEvent()
        {
        }

        public DaysLeftActiveCollectibleBoardEvent(CollectibleBoardEventId eventId)
        {
        }
    }
}