using Metaplay.Core.Model;
using Metaplay.Core.Math;
using System;

namespace GameLogic.Player.Director.Actions
{
    [MetaSerializableDerived(10)]
    public class ShowTutorialDragSerializedAction : ISerializedAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private F32 Delay { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private int ItemTypeFrom { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private int ItemTypeTo { get; set; }

        private ShowTutorialDragSerializedAction()
        {
        }

        public ShowTutorialDragSerializedAction(F32 delay, int itemTypeFrom, int itemTypeTo)
        {
        }
    }
}