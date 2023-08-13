using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1033)]
    public class PlayerPointsInLeaderboardEvent : TypedPlayerPropertyId<int>
    {
        [MetaMember(1, 0)]
        private LeaderboardEventId EventId { get; set; }

        private static int InvalidResult;
        public override string DisplayName { get; }

        public PlayerPointsInLeaderboardEvent()
        {
        }

        public PlayerPointsInLeaderboardEvent(LeaderboardEventId eventId)
        {
        }
    }
}