using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Config.Costs;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Requirements
{
    [MetaSerializableDerived(6)]
    public class CostRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        public ICost RequiredCost { get; set; }
    }
}
