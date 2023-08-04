using Metaplay.Core.Model;
using Merge;

namespace GameLogic.Player.Director.Conditions
{
    [MetaSerializableDerived(1)]
    public class BoardIsVisible : IScriptedEventCondition
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MergeBoardId BoardId { get; set; }

        private BoardIsVisible()
        {
        }

        public BoardIsVisible(MergeBoardId boardId)
        {
        }
    }
}