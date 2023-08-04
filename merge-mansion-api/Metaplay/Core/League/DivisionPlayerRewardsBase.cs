using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using Metaplay.Core.Rewards;

namespace Metaplay.Core.League
{
    [MetaReservedMembers(100, 200)]
    public abstract class DivisionPlayerRewardsBase : IDivisionRewards
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public bool IsClaimed { get; set; }

        IEnumerable<MetaReward> Metaplay.Core.League.IDivisionRewards.Rewards { get; }
        public abstract List<MetaPlayerRewardBase> Rewards { get; set; }

        protected DivisionPlayerRewardsBase()
        {
        }

        [MetaSerializableDerived(100)]
        public class Default : DivisionPlayerRewardsBase
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public sealed override List<MetaPlayerRewardBase> Rewards { get; set; }

            private Default()
            {
            }

            public Default(List<MetaPlayerRewardBase> rewards)
            {
            }
        }
    }
}