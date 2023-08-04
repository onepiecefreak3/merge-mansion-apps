using Metaplay.Core.Model;
using System;

namespace GameLogic.Player
{
    [MetaSerializableDerived(1)]
    public class DefaultAnalyticsContext : AnalyticsContext
    {
        public DefaultAnalyticsContext()
        {
        }

        public DefaultAnalyticsContext(string context, string target)
        {
        }
    }
}