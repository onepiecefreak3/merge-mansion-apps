using System.Collections.Generic;
using Metaplay.Core.Model;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(9)]
    [MetaSerializable]
    public class TriggerPopup : IDirectorAction
    {
        [MetaMember(1, 0)]
        private string PopupId { get; set; }
        [MetaMember(2, 0)]
        private List<string> Args { get; set; }
    }
}
