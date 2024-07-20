using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Guild
{
    [AnalyticsEvent(1101, null, 1, "The initial member was added to the guild.", true, true, false)]
    public class GuildEventFounderJoined : GuildEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [FirebaseAnalyticsIgnore]
        public GuildEventMemberInfo FoundingMember { get; set; }
        public override string EventDescription { get; }

        private GuildEventFounderJoined()
        {
        }

        public GuildEventFounderJoined(GuildEventMemberInfo foundingMember)
        {
        }
    }
}