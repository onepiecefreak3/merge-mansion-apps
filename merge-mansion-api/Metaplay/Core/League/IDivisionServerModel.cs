using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace Metaplay.Core.League
{
    [LeaguesEnabledCondition]
    [MetaSerializable]
    public interface IDivisionServerModel
    {
        Dictionary<int, EntityId> ParticipantIndexToEntityId { get; }
    }
}