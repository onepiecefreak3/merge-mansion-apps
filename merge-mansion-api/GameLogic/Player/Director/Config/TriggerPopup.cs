using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Director.Config
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
