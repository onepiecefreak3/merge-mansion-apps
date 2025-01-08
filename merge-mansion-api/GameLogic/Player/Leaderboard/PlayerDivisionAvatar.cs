using Metaplay.Core.Model;
using Metaplay.Core.League.Player;
using System;

namespace GameLogic.Player.Leaderboard
{
    [PlayerLeaguesEnabledCondition]
    [MetaSerializableDerived(150)]
    [MetaSerializable]
    public class PlayerDivisionAvatar : PlayerDivisionAvatarBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string DisplayName;
        [MetaMember(2, (MetaMemberFlags)0)]
        [ServerOnly]
        public string AssociationId;
        private PlayerDivisionAvatar()
        {
        }

        public PlayerDivisionAvatar(string displayName, string associationId)
        {
        }
    }
}