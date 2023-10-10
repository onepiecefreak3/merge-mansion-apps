using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Director.Actions
{
    [MetaSerializableDerived(9)]
    public class SetTabSerializedAction : ISerializedAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private string TargetId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private int TabIndex { get; set; }

        private SetTabSerializedAction()
        {
        }

        public SetTabSerializedAction(string targetId, int tabIndex)
        {
        }
    }
}