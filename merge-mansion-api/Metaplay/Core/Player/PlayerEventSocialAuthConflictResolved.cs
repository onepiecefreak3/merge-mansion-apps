using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Player
{
    [AnalyticsEvent(1003, null, 1, "Player has resolved an authentication conflict, and that has affected the player's authentication record. An authentication conflict is situation where multiple authentication sources disagree on which player account is active. The event contents describe the actions done to this player to resolve the conflict.", true, true, false)]
    public class PlayerEventSocialAuthConflictResolved : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public PlayerEventSocialAuthConflictResolved.ResolutionOperation Operation { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public AuthenticationKey DeviceIdKey { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public AuthenticationKey SocialIdKey { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public EntityId OtherPlayerId { get; set; }
        public override string EventDescription { get; }

        public PlayerEventSocialAuthConflictResolved()
        {
        }

        public PlayerEventSocialAuthConflictResolved(PlayerEventSocialAuthConflictResolved.ResolutionOperation operation, AuthenticationKey deviceIdKey, AuthenticationKey socialIdKey, EntityId otherPlayerId)
        {
        }

        [MetaSerializable]
        public enum ResolutionOperation
        {
            DeviceMigrationSource = 0,
            DeviceMigrationDestination = 1,
            SocialMigrationSource = 2,
            SocialMigrationDestination = 3,
            SocialMigrationKeyAdded = 4
        }
    }
}