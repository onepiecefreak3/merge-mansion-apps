using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace GameLogic.Player.Director.Actions
{
    [MetaSerializableDerived(5)]
    public class TriggerPopupSerializedAction : ISerializedAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private string PopupId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private List<ISerializableArg> Args { get; set; }

        private TriggerPopupSerializedAction()
        {
        }

        public TriggerPopupSerializedAction(string popupId, List<string> args)
        {
        }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Obsolete("Replaced by Args. Required for migration.")]
        private List<string> Args_DEPRECATED { get; set; }

        public TriggerPopupSerializedAction(string popupId, List<ISerializableArg> args)
        {
        }
    }
}