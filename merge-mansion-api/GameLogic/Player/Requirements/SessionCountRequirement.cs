using System;
using Metaplay.Core.Model;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(15)]
    [MetaSerializable]
    public class SessionCountRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        public Nullable<int> Min; // 0x10
        [MetaMember(2, 0)]
        public Nullable<int> Max; // 0x18
        [MetaMember(3, 0)]
        public Nullable<int> HoursSince; // 0x20
        public SessionCountRequirement()
        {
        }

        public SessionCountRequirement(int? hoursSince, int? min, int? max)
        {
        }
    }
}