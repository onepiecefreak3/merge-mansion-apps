using Metaplay.Core.Model;

namespace Metaplay.Core.League
{
    [MetaSerializable]
    [LeaguesEnabledCondition]
    public interface IDivisionParticipantConclusionResult
    {
        EntityId ParticipantId { get; }
    }
}