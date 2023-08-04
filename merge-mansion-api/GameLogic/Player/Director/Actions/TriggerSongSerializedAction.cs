using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Director.Actions
{
    [MetaSerializableDerived(6)]
    public class TriggerSongSerializedAction : ISerializedAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private string SongAlias { get; set; }

        private TriggerSongSerializedAction()
        {
        }

        public TriggerSongSerializedAction(string songAlias)
        {
        }
    }
}