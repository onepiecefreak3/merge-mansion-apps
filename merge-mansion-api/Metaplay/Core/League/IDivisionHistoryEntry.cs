using Metaplay.Core.Model;

namespace Metaplay.Core.League
{
    [LeaguesEnabledCondition]
    [MetaSerializable]
    public interface IDivisionHistoryEntry
    {
        EntityId DivisionId { get; }

        DivisionIndex DivisionIndex { get; }

        IDivisionRewards Rewards { get; }
    }
}