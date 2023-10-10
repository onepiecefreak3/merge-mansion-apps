using Metaplay.Core.Model;
using System;
using System.Runtime.Serialization;

namespace Metaplay.Core.League
{
    [MetaReservedMembers(100, 200)]
    public abstract class DivisionParticipantStateBase<TDivisionScore> : IDivisionParticipantState
    {
        public EntityId ParticipantId { get; set; }
        public TDivisionScore DivisionScore { get; set; }
        public int SortOrderIndex { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        [ServerOnly]
        public int AvatarDataEpoch { get; set; }

        [MetaMember(102, (MetaMemberFlags)0)]
        [ServerOnly]
        public IDivisionRewards ResolvedDivisionRewards { get; set; }

        [IgnoreDataMember]
        IDivisionScore Metaplay.Core.League.IDivisionParticipantState.DivisionScore { get; set; }

        protected DivisionParticipantStateBase()
        {
        }

        protected DivisionParticipantStateBase(EntityId participantId)
        {
        }

        public int ParticipantIndex { get; set; }
        public abstract string ParticipantInfo { get; }
    }
}