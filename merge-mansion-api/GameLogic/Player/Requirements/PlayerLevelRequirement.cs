using System;
using Metaplay.Core.Model;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(9)]
    [MetaSerializable]
    public class PlayerLevelRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int? Min;
        [MetaMember(2, (MetaMemberFlags)0)]
        public int? Max;
        public PlayerLevelRequirement()
        {
        }

        public PlayerLevelRequirement(int? min, int? max)
        {
        }
    }
}