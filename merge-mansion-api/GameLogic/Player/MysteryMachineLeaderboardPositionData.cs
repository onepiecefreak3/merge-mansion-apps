using Metaplay.Core.Model;
using System;

namespace GameLogic.Player
{
    [MetaSerializable]
    public struct MysteryMachineLeaderboardPositionData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Position { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int TotalPositionCount { get; set; }
    }
}