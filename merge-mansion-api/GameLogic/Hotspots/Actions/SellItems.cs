using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Merge;
using Metaplay.GameLogic.Player.Director.Config;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Hotspots.Actions
{
    [MetaSerializableDerived(10)]
    public class SellItems : IDirectorAction
    {
        [MetaMember(1, 0)]
        private MergeBoardId MergeBoardId { get; set; }
        [MetaMember(2, 0)]
        private string Tag { get; set; }
        [MetaMember(3, 0)]
        private MetaDuration SellDuration { get; set; }
    }
}
