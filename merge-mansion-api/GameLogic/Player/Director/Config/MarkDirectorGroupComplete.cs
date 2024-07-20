using Metaplay.Core.Model;
using GameLogic.Config;
using System.Runtime.Serialization;
using System;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(8)]
    public class MarkDirectorGroupComplete : IDirectorAction
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        private DirectorGroupId DirectorGroupId { get; set; }

        private MarkDirectorGroupComplete()
        {
        }

        public MarkDirectorGroupComplete(DirectorGroupId directorGroupId)
        {
        }

        [IgnoreDataMember]
        public bool IsVisualAction { get; }
    }
}