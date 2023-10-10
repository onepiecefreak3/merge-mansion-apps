using System;
using Metaplay.Core;
using Metaplay.Core.Model;
using System.Runtime.Serialization;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(11)]
    [MetaBlockedMembers(new int[] { 3 })]
    public class PlayerCurrentTimeRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        public Nullable<MetaTime> StartInclusive { get; set; }

        [MetaMember(2, 0)]
        public Nullable<MetaTime> EndExclusive { get; set; }

        [IgnoreDataMember]
        public MetaTime? StartTimeInclusive { get; }

        private PlayerCurrentTimeRequirement()
        {
        }

        public PlayerCurrentTimeRequirement(MetaTime? startInclusive, MetaTime? endExclusive)
        {
        }

        [IgnoreDataMember]
        public bool HasStartTime { get; }

        [IgnoreDataMember]
        public MetaTime? EndTimeExclusive { get; }

        [IgnoreDataMember]
        public bool HasEndTime { get; }
    }
}