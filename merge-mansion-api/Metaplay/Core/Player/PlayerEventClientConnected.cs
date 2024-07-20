using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Metaplay.Core.Session;
using System;

namespace Metaplay.Core.Player
{
    [AnalyticsEvent(1005, null, 1, "Client has connected to the server.", true, true, false)]
    [AnalyticsEventKeywords(new string[] { "Session" })]
    public class PlayerEventClientConnected : PlayerEventBase
    {
        [MetaMember(7, (MetaMemberFlags)0)]
        public SessionToken SessionToken { get; set; }

        [MetaMember(1, (MetaMemberFlags)0)]
        public string DeviceId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DeviceModel { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int LogicVersion { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [FirebaseAnalyticsIgnore]
        public PlayerTimeZoneInfo TimeZoneInfo { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [FirebaseAnalyticsIgnore]
        public PlayerLocation? Location { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string ClientVersion { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public int SessionNumber { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public AuthenticationKey AuthKey { get; set; }
        public override string EventDescription { get; }

        private PlayerEventClientConnected()
        {
        }

        public PlayerEventClientConnected(SessionToken sessionToken, string deviceId, string deviceModel, int logicVersion, PlayerTimeZoneInfo timeZoneInfo, PlayerLocation? location, string clientVersion, int sessionNumber, AuthenticationKey authKey)
        {
        }
    }
}