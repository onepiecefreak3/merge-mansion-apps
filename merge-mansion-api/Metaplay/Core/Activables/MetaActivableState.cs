using System.Runtime.Serialization;
using System;
using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace Metaplay.Core.Activables
{
    public abstract class MetaActivableState<TId, TInfo> : MetaActivableState
    {
        [IgnoreDataMember]
        public abstract TId ActivableId { get; set; }

        [IgnoreDataMember]
        public TInfo ActivableInfo { get; set; }

        [IgnoreDataMember]
        public override MetaActivableParams ActivableParams { get; }
        public override bool IsValidState { get; }

        protected MetaActivableState()
        {
        }

        protected MetaActivableState(TInfo activableInfo)
        {
        }
    }

    [MetaSerializable]
    public abstract class MetaActivableState : MetaActivableStateStorage
    {
        [IgnoreDataMember]
        public abstract MetaActivableParams ActivableParams { get; }
        public virtual bool IsValidState { get; }

        protected MetaActivableState()
        {
        }

        [MetaSerializable]
        [MetaBlockedMembers(new int[] { 4 })]
        public struct Activation
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public MetaDuration UtcOffset;
            [MetaMember(2, (MetaMemberFlags)0)]
            public MetaTime StartedAt;
            [MetaMember(3, (MetaMemberFlags)0)]
            public MetaTime? EndAt;
            [MetaMember(8, (MetaMemberFlags)0)]
            public bool EndedExplicitly;
            [MetaMember(6, (MetaMemberFlags)0)]
            public MetaTime? CooldownEndAt;
            [MetaMember(5, (MetaMemberFlags)0)]
            public int NumConsumed;
            [MetaMember(7, (MetaMemberFlags)0)]
            public bool IsFinalized;
            [IgnoreDataMember]
            public PlayerLocalTime LocalStartedAt { get; }
        }

        [MetaSerializable]
        public class DebugState
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public MetaActivableState.DebugPhase Phase { get; set; }

            private DebugState()
            {
            }

            public DebugState(MetaActivableState.DebugPhase phase)
            {
            }
        }

        [MetaSerializable]
        public enum DebugPhase
        {
            Preview = 0,
            Active = 1,
            EndingSoon = 2,
            Review = 3,
            Inactive = 4
        }
    }

    public abstract class MetaActivableState<TId> : MetaActivableState
    {
        [IgnoreDataMember]
        public abstract TId ActivableId { get; }

        protected MetaActivableState()
        {
        }
    }
}