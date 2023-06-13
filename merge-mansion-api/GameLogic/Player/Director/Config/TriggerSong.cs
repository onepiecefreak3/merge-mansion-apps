using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(11)]
    public class TriggerSong : IDirectorAction
    {
        [MetaMember(1, 0)]
        private string SongAlias { get; set; }
    }
}
