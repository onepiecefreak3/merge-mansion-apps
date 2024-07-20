using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Guild
{
    [AnalyticsEvent(1105, null, 1, "A member was removed from the guild to repair an inconsistency between the player entity and the guild entity, where the player and guild disagree about the player's membership in the guild. This can only happen if DB is an inconsistent state, which may be caused by partial or non-atomically sharded DB rollbacks.", true, true, false)]
    public class GuildEventMemberRemovedDueToInconsistency : GuildEventBase
    {
        [FirebaseAnalyticsIgnore]
        [MetaMember(1, (MetaMemberFlags)0)]
        public GuildEventMemberInfo RemovedMember { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public GuildEventMemberRemovedDueToInconsistency.InconsistencyType Type { get; set; }
        public override string EventDescription { get; }

        private GuildEventMemberRemovedDueToInconsistency()
        {
        }

        public GuildEventMemberRemovedDueToInconsistency(GuildEventMemberInfo removedMember, GuildEventMemberRemovedDueToInconsistency.InconsistencyType type)
        {
        }

        [MetaSerializable]
        public enum InconsistencyType
        {
            SubscribeAttemptMemberInstanceIdDiffers = 0,
            JoinAttemptAlreadyMember = 1,
            PeekKickedStateAttemptMemberInstanceIdDiffers = 2
        }
    }
}