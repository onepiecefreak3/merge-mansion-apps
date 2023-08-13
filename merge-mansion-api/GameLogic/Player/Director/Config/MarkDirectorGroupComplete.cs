using Metaplay.Core.Model;
using GameLogic.Config;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(8)]
    public class MarkDirectorGroupComplete : IDirectorAction
    {
        [MetaMember(1, 0)]
        private DirectorGroupId DirectorGroupId { get; set; }

        private MarkDirectorGroupComplete()
        {
        }

        public MarkDirectorGroupComplete(DirectorGroupId directorGroupId)
        {
        }
    }
}