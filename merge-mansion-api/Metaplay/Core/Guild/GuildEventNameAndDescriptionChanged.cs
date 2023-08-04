using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Guild
{
    [AnalyticsEvent(1106, null, 1, "The guild's name and/or description were changed by a member or an admin.", true, true, false)]
    public class GuildEventNameAndDescriptionChanged : GuildEventBase
    {
        [FirebaseAnalyticsIgnore]
        [MetaMember(1, (MetaMemberFlags)0)]
        public GuildEventInvokerInfo Invoker { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string OldName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string OldDescription { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string NewName { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string NewDescription { get; set; }
        public override string EventDescription { get; }

        private GuildEventNameAndDescriptionChanged()
        {
        }

        public GuildEventNameAndDescriptionChanged(GuildEventInvokerInfo invoker, string oldName, string oldDescription, string newName, string newDescription)
        {
        }
    }
}