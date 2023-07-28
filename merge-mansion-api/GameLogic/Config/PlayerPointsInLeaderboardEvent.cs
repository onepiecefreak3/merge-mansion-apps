using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1033)]
    [MetaSerializable]
    public class PlayerPointsInLeaderboardEvent : TypedPlayerPropertyId<int>
    {
        [MetaMember(1, 0)]
        private LeaderboardEventId EventId { get; set; }
    }
}
