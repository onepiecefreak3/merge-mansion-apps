using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using Metaplay.Core.Rewards;

namespace Metaplay.Core.League
{
    [MetaSerializable]
    public interface IDivisionRewards
    {
        bool IsClaimed { get; set; }

        IEnumerable<MetaReward> Rewards { get; }
    }
}