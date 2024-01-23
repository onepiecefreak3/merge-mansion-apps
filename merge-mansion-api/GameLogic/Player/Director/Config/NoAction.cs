using Metaplay.Core.Model;
using System.Runtime.Serialization;
using System;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(1)]
    public class NoAction : IDirectorAction
    {
        public NoAction()
        {
        }

        [IgnoreDataMember]
        public bool IsVisualAction { get; }
    }
}