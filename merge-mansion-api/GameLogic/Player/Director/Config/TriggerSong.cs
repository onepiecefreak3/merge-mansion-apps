using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(11)]
    public class TriggerSong : IDirectorAction
    {
        [MetaMember(1, 0)]
        private string SongAlias { get; set; }

        private TriggerSong()
        {
        }

        public TriggerSong(string songAlias)
        {
        }
    }
}