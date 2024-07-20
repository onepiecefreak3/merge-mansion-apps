using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1036)]
    public class PlayerEnergySpentInLastNDays : TypedPlayerPropertyId<long>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int Days { get; set; }
        public override string DisplayName { get; }

        public PlayerEnergySpentInLastNDays()
        {
        }

        public PlayerEnergySpentInLastNDays(int days)
        {
        }
    }
}