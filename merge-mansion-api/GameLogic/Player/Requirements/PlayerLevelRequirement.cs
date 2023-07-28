using System;
using Metaplay.Core.Model;

namespace GameLogic.Player.Requirements
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
