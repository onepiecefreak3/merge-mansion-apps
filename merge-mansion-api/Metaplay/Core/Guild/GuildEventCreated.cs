using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Guild
{
    [AnalyticsEvent(1100, null, 1, "Guild was created. At this point there are 0 members in the guild.", true, true, false)]
    public class GuildEventCreated : GuildEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string Description { get; set; }
        public override string EventDescription { get; }

        private GuildEventCreated()
        {
        }

        public GuildEventCreated(string displayName, string description)
        {
        }
    }
}