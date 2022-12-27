using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Area;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Requirements
{
    [MetaSerializableDerived(10)]
    public class AreaCompletedRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        public MetaRef<AreaInfo> AreaRef { get; set; }
    }
}
