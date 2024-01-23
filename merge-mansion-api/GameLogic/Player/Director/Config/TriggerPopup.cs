using System.Collections.Generic;
using Metaplay.Core.Model;
using System;
using System.Runtime.Serialization;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(9)]
    [MetaBlockedMembers(new int[] { 2 })]
    public class TriggerPopup : IDirectorAction
    {
        [MetaMember(1, 0)]
        private string PopupId { get; set; }

        [MetaMember(2, 0)]
        private List<string> Args { get; set; }

        private TriggerPopup()
        {
        }

        public TriggerPopup(string popupId, List<string> args)
        {
        }

        public TriggerPopup(string popupId, List<ISerializableArg> args)
        {
        }

        public TriggerPopup(string popupId, IEnumerable<string> args)
        {
        }

        [IgnoreDataMember]
        public bool IsVisualAction { get; }
    }
}