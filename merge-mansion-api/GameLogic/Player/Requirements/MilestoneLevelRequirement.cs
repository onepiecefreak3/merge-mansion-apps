using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(51)]
    public class MilestoneLevelRequirement : PlayerRequirement
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public int? Min;
        [MetaMember(3, (MetaMemberFlags)0)]
        public int? Max;
        [MetaMember(1, (MetaMemberFlags)0)]
        private string ItemId { get; set; }

        public MilestoneLevelRequirement()
        {
        }

        public MilestoneLevelRequirement(string itemId, int? min, int? max)
        {
        }
    }
}