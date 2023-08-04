using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Guild
{
    [AnalyticsEvent(1107, "Model Schema Migrated", 1, "The GuildModel schema was migrated from an old version to the current version (at the time of running the event)", true, true, false)]
    public class GuildEventModelSchemaMigrated : GuildEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int FromVersion { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int ToVersion { get; set; }
        public override string EventDescription { get; }

        private GuildEventModelSchemaMigrated()
        {
        }

        public GuildEventModelSchemaMigrated(int fromVersion, int toVersion)
        {
        }
    }
}