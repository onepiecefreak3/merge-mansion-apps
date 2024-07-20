using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Guild
{
    [AnalyticsEvent(1102, null, 1, "A member (other than the initial member) joined the guild. Initial member is called the Founder, and uses a separate event.", true, true, false)]
    public class GuildEventMemberJoined : GuildEventBase
    {
        [FirebaseAnalyticsIgnore]
        [MetaMember(1, (MetaMemberFlags)0)]
        public GuildEventMemberInfo JoiningMember { get; set; }
        public override string EventDescription { get; }

        private GuildEventMemberJoined()
        {
        }

        public GuildEventMemberJoined(GuildEventMemberInfo joiningMember)
        {
        }
    }
}