using Metaplay.Core.Model;
using System;
using Metaplay.Core.Math;

namespace Game.Logic.Message
{
    [MetaSerializable]
    public struct MysteryMachineLeaderboardSelfEntry
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool Valid;
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Position;
        [MetaMember(3, (MetaMemberFlags)0)]
        public int Score;
        [MetaMember(4, (MetaMemberFlags)0)]
        public F64 Percentile;
    }
}