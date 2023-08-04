using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Director.Actions
{
    [MetaSerializableDerived(7)]
    public class ShowTutorialFingerSerializedAction : ISerializedAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private string TargetId { get; set; }

        private ShowTutorialFingerSerializedAction()
        {
        }

        public ShowTutorialFingerSerializedAction(string targetId)
        {
        }
    }
}