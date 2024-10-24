using System;

namespace GameLogic.Player.Leaderboard
{
    public interface IMetacoreLeagueAvatar
    {
        string AssociationId { get; }

        string DisplayName { get; }
    }
}