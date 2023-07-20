using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Requirements
{
    [MetaSerializableDerived(9)]
    [MetaSerializable]
    public class PlayerLevelRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        public Nullable<int> Min { get; set; } // 0x10
        [MetaMember(2, 0)]
        public Nullable<int> Max { get; set; } // 0x18
    }
}
