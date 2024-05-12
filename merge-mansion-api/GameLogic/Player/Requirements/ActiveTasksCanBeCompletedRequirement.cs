using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(39)]
    public class ActiveTasksCanBeCompletedRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int RequiredAmount { get; set; }

        public ActiveTasksCanBeCompletedRequirement()
        {
        }

        public ActiveTasksCanBeCompletedRequirement(int amount)
        {
        }
    }
}