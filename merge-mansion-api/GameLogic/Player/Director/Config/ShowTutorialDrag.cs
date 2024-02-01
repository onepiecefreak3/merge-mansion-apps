using Metaplay.Core.Model;
using Metaplay.Core.Math;
using System;
using System.Runtime.Serialization;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(15)]
    public class ShowTutorialDrag : IDirectorAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public F32 Delay { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int ItemTypeFrom { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int ItemTypeTo { get; set; }

        [IgnoreDataMember]
        public bool IsVisualAction { get; }

        private ShowTutorialDrag()
        {
        }

        public ShowTutorialDrag(F32 delay, int itemTypeFrom, int itemTypeTo)
        {
        }
    }
}