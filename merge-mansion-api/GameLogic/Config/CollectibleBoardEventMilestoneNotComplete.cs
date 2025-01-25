using Metaplay.Core.Model;
using System;
using Code.GameLogic.GameEvents;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1053)]
    public class CollectibleBoardEventMilestoneNotComplete : PlayerPropertyMatcher<string>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private CollectibleBoardEventId EventId { get; set; }
        public override string DisplayName { get; }

        public CollectibleBoardEventMilestoneNotComplete()
        {
        }

        public CollectibleBoardEventMilestoneNotComplete(CollectibleBoardEventId eventId)
        {
        }
    }
}