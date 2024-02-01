using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(27)]
    public class SideBoardEventTaskCompletedRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private EventTaskId sideBoardEventTaskId;
        public SideBoardEventTaskCompletedRequirement()
        {
        }

        public SideBoardEventTaskCompletedRequirement(EventTaskId sideBoardEventTaskId)
        {
        }
    }
}