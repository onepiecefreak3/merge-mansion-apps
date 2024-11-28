using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Metaplay.Core.Session;
using System;

namespace Metaplay.Core.Player
{
    [AnalyticsEvent(1006, null, 1, "The connection from client to the server has been lost.", true, true, false)]
    [AnalyticsEventKeywords(new string[] { "Session" })]
    public class PlayerEventClientDisconnected : PlayerEventBase
    {
        [MetaMember(3, (MetaMemberFlags)0)]
        public SessionToken SessionToken { get; set; }
        public override string EventDescription { get; }

        public PlayerEventClientDisconnected()
        {
        }

        public PlayerEventClientDisconnected(SessionToken sessionToken)
        {
        }
    }
}