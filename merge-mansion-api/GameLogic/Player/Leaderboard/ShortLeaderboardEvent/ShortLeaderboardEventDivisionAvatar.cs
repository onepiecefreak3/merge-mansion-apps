using Metaplay.Core.League.Player;
using Metaplay.Core.Model;
using System;
using Metaplay.Core.Player;

namespace GameLogic.Player.Leaderboard.ShortLeaderboardEvent
{
    [MetaSerializableDerived(201)]
    [MetaSerializable]
    [PlayerLeaguesEnabledCondition]
    public class ShortLeaderboardEventDivisionAvatar : PlayerDivisionAvatarBase, IMetacoreLeagueAvatar
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [ServerOnly]
        public string AssociationId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [ServerOnly]
        public PlayerSegmentId PlayerSegmentId { get; set; }

        [ServerOnly]
        [MetaMember(4, (MetaMemberFlags)0)]
        public int SegmentIdPriority { get; set; }

        [ServerOnly]
        [MetaMember(5, (MetaMemberFlags)0)]
        public string BotType { get; set; }

        private ShortLeaderboardEventDivisionAvatar()
        {
        }

        public ShortLeaderboardEventDivisionAvatar(string displayName, string associationId, PlayerSegmentId playerSegmentId, int segmentIdPriority, string botType)
        {
        }
    }
}