using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1040)]
    public class AverageEnergySpentInNDays : TypedPlayerPropertyId<int>
    {
        private static int InvalidResult;
        [MetaMember(1, (MetaMemberFlags)0)]
        private int Days { get; set; }
        public override string DisplayName { get; }

        public AverageEnergySpentInNDays()
        {
        }

        public AverageEnergySpentInNDays(int days)
        {
        }
    }
}