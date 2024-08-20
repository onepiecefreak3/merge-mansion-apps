using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Guild
{
    [AnalyticsEvent(1103, null, 1, "A member left the guild (by their own request).", true, true, false)]
    public class GuildEventMemberLeft : GuildEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [FirebaseAnalyticsIgnore]
        public GuildEventMemberInfo LeavingMember { get; set; }
        public override string EventDescription { get; }

        private GuildEventMemberLeft()
        {
        }

        public GuildEventMemberLeft(GuildEventMemberInfo leavingMember)
        {
        }
    }
}