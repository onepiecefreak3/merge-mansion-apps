using Metaplay.Core.Model;
using System;
using System.Runtime.Serialization;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(14)]
    public class SetTab : IDirectorAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string TargetId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int TabIndex { get; set; }

        private SetTab()
        {
        }

        public SetTab(string targetId, int tabIndex)
        {
        }

        [IgnoreDataMember]
        public bool IsVisualAction { get; }
    }
}