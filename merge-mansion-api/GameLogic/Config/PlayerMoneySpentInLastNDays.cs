using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Math;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Player;

namespace merge_mansion_api.GameLogic.Config
{
    [MetaSerializableDerived(1035)]
    public class PlayerMoneySpentInLastNDays : TypedPlayerPropertyId<F64>
    {
        [MetaMember(1, 0)]
        private int Days { get; set; }
    }
}
