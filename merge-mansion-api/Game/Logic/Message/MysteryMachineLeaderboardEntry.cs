using Metaplay.Core.Model;
using System;
using Metaplay.Core;

namespace Game.Logic.Message
{
    [MetaSerializable]
    public struct MysteryMachineLeaderboardEntry
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string PlayerName;
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Score;
        [MetaMember(3, (MetaMemberFlags)0)]
        public EntityId EntityId;
    }
}