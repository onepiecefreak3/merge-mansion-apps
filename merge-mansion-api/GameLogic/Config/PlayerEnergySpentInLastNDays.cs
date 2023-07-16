using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Player;

namespace Metaplay.GameLogic.Config
{
    [MetaSerializableDerived(1036)]
    public class PlayerEnergySpentInLastNDays : TypedPlayerPropertyId<long>
    {
        [MetaMember(1, 0)]
        private int Days { get; set; }
    }
}
