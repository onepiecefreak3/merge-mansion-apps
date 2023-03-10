using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Merge;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items
{
    public class PortalFeatures
    {
        [MetaMember(1, 0)]
        public bool IsPortal { get; set; }
        [MetaMember(2, 0)]
        public MergeBoardId TargetBoardId { get; set; }
    }
}
