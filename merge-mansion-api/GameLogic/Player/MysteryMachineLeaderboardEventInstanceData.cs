using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;
using System;

namespace GameLogic.Player
{
    [MetaSerializable]
    public struct MysteryMachineLeaderboardEventInstanceData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineEventId EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public EventInstanceId EventInstanceId { get; set; }
    }
}