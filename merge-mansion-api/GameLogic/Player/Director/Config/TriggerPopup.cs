using System.Collections.Generic;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(9)]
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
    }
}