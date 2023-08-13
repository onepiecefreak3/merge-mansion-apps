using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.League
{
    [MetaSerializable]
    [LeaguesEnabledCondition]
    public interface IDivisionParticipantState
    {
        EntityId ParticipantId { get; set; }

        IDivisionScore DivisionScore { get; set; }

        int SortOrderIndex { get; set; }

        int AvatarDataEpoch { get; set; }

        IDivisionRewards ResolvedDivisionRewards { get; set; }
    }
}