using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public struct SideBoardEventClaimedLevelData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Level;
        [MetaMember(2, (MetaMemberFlags)0)]
        public SideBoardEventLevelType Type;
    }
}