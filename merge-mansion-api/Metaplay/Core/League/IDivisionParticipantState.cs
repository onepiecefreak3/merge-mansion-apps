using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.League
{
    [LeaguesEnabledCondition]
    [MetaSerializable]
    public interface IDivisionParticipantState
    {
        EntityId ParticipantId { get; set; }

        IDivisionScore DivisionScore { get; set; }

        int SortOrderIndex { get; set; }

        int AvatarDataEpoch { get; set; }

        IDivisionRewards ResolvedDivisionRewards { get; set; }

        int ParticipantIndex { get; set; }

        string ParticipantInfo { get; }
    }
}