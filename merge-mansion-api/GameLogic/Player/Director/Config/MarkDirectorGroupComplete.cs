using Metaplay.Core.Model;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(8)]
    [MetaSerializable]
    public class MarkDirectorGroupComplete : IDirectorAction
    {
        [MetaMember(1, 0)]
        private DCGroupId DirectorGroupId { get; set; }
    }
}
