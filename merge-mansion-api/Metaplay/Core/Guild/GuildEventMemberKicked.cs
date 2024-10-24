using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Guild
{
    [AnalyticsEvent(1104, null, 1, "A member was kicked by a fellow member or an admin.", true, true, false)]
    public class GuildEventMemberKicked : GuildEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [FirebaseAnalyticsIgnore]
        public GuildEventMemberInfo KickedMember { get; set; }

        [FirebaseAnalyticsIgnore]
        [MetaMember(2, (MetaMemberFlags)0)]
        public GuildEventInvokerInfo KickInvoker { get; set; }
        public override string EventDescription { get; }

        private GuildEventMemberKicked()
        {
        }

        public GuildEventMemberKicked(GuildEventMemberInfo kickedMember, GuildEventInvokerInfo kickInvoker)
        {
        }
    }
}