using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace Metaplay.Core.League
{
    [MetaSerializable]
    [LeaguesEnabledCondition]
    public interface IDivisionServerModel
    {
        Dictionary<int, EntityId> ParticipantIndexToEntityId { get; }
    }
}