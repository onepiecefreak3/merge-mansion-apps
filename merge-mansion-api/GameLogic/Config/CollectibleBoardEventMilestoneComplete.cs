using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;
using Code.GameLogic.GameEvents;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1052)]
    public class CollectibleBoardEventMilestoneComplete : TypedPlayerPropertyId<int>
    {
        private static int FailIndex;
        public override string DisplayName { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        private CollectibleBoardEventId EventId { get; set; }

        public CollectibleBoardEventMilestoneComplete()
        {
        }

        public CollectibleBoardEventMilestoneComplete(CollectibleBoardEventId eventId)
        {
        }
    }
}