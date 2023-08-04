using Metaplay.Core.Math;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1035)]
    [MetaSerializable]
    public class PlayerMoneySpentInLastNDays : TypedPlayerPropertyId<F64>
    {
        [MetaMember(1, 0)]
        private int Days { get; set; }
        public override string DisplayName { get; }

        public PlayerMoneySpentInLastNDays()
        {
        }

        public PlayerMoneySpentInLastNDays(int days)
        {
        }
    }
}