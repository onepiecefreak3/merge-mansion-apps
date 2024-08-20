using Metaplay.Core.Model;

namespace Metaplay.Core.League
{
    [LeaguesEnabledCondition]
    [MetaSerializable]
    public interface IDivisionParticipantConclusionResult
    {
        EntityId ParticipantId { get; }
    }
}