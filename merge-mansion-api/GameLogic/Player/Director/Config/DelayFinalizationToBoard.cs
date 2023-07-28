using GameLogic.Merge;
using Metaplay.Core.Model;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(3)]
    [MetaSerializable]
    public class DelayFinalizationToBoard : IDirectorAction
    {
        [MetaMember(1, 0)]
        private MergeBoardId BoardId { get; set; }
    }
}
