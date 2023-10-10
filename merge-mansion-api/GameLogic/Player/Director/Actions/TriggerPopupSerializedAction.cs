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

        [MetaMember(2, (MetaMemberFlags)0)]
        private List<string> Args { get; set; }

        private TriggerPopupSerializedAction()
        {
        }

        public TriggerPopupSerializedAction(string popupId, List<string> args)
        {
        }

        [Obsolete("Replaced by Args. Required for migration.")]
        [MetaMember(2, (MetaMemberFlags)0)]
        private List<string> Args_DEPRECATED { get; set; }

        public TriggerPopupSerializedAction(string popupId, List<ISerializableArg> args)
        {
        }
    }
}