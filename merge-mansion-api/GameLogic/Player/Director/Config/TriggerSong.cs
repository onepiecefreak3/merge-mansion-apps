using Metaplay.Core.Model;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(11)]
    [MetaSerializable]
    public class TriggerSong : IDirectorAction
    {
        [MetaMember(1, 0)]
        private string SongAlias { get; set; }
    }
}
