using GameLogic.Merge;
using Metaplay.Core.Model;
using Merge;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(3)]
    public class DelayFinalizationToBoard : IDirectorAction
    {
        [MetaMember(1, 0)]
        private MergeBoardId BoardId { get; set; }

        private DelayFinalizationToBoard()
        {
        }

        public DelayFinalizationToBoard(MergeBoardId boardId)
        {
        }
    }
}