using Metaplay.Core.Model;

namespace Metaplay.Core.League
{
    [MetaSerializable]
    [LeaguesEnabledCondition]
    public interface IDivisionHistoryEntry
    {
        EntityId DivisionId { get; }

        DivisionIndex DivisionIndex { get; }

        IDivisionRewards Rewards { get; }
    }
}