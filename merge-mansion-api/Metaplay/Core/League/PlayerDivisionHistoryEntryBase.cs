using Metaplay.Core.Model;

namespace Metaplay.Core.League
{
    [LeaguesEnabledCondition]
    [MetaReservedMembers(100, 200)]
    public abstract class PlayerDivisionHistoryEntryBase : IDivisionHistoryEntry
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public EntityId DivisionId { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        public DivisionIndex DivisionIndex { get; set; }

        [MetaMember(102, (MetaMemberFlags)0)]
        public IDivisionRewards Rewards { get; set; }

        protected PlayerDivisionHistoryEntryBase(EntityId divisionId, DivisionIndex divisionIndex, IDivisionRewards rewards)
        {
        }
    }
}