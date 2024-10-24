using Metaplay.Core.Model;
using System;

namespace Game.Logic.Message
{
    [MetaSerializable]
    public struct MysteryMachineLeaderboardPercentileData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool Valid;
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Index;
        [MetaMember(3, (MetaMemberFlags)0)]
        public int MinScore;
    }
}