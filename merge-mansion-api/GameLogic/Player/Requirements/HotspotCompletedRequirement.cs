using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Hotspots;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Requirements
{
    [MetaSerializableDerived(2)]
    public class HotspotCompletedRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        public MetaRef<HotspotDefinition> hotspot { get; set; } // 0x10
    }
}
