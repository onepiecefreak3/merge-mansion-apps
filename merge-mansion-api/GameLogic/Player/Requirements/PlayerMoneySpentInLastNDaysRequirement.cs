using Metaplay.Core.Model;
using Metaplay.Core.Math;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(58)]
    public class PlayerMoneySpentInLastNDaysRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public F64 MinMoneySpent { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Days { get; set; }

        private PlayerMoneySpentInLastNDaysRequirement()
        {
        }

        public PlayerMoneySpentInLastNDaysRequirement(F64 minMoneySpent, int days)
        {
        }
    }
}