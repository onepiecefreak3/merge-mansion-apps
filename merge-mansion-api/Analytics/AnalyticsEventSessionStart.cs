using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using Metaplay.Core;

namespace Analytics
{
    [AnalyticsEvent(114, "Session start", 1, null, false, true, false)]
    [MetaBlockedMembers(new int[] { 3, 4, 5, 6, 10, 11 })]
    public class AnalyticsEventSessionStart : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("total_logins")]
        [Description("How many logins happened for the player")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public int TotalLogins { get; set; }

        [JsonProperty("created")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("When the player was created")]
        public MetaTime CreatedAt { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("user_first_touch_timestamp")]
        [Description("When player first started playing")]
        public MetaTime FirstSession { get; set; }

        [Description("String identifying the device")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("device")]
        public string Device { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("location")]
        [Description("String describing approximate location")]
        public string Location { get; set; }

        [Description("How many decorations player owns")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("decoration_count_owned")]
        public int DecorationsOwned { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("How many decorations are visible")]
        [JsonProperty("decoration_count_visible")]
        public int DecorationVisible { get; set; }

        [Description("Player local time (by device) offset in hour from utc (+ or -) ")]
        [JsonProperty("player_time_offset")]
        [MetaMember(14, (MetaMemberFlags)0)]
        public MetaDuration PlayerTimeOffset { get; set; }

        [Description("Attached authentication methods")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [JsonProperty("attached_auth_methods")]
        public string AuthenticationMethods { get; set; }

        [Description("Client Version")]
        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("client_version")]
        public string ClientVersion { get; set; }

        [JsonProperty("is_developer")]
        [MetaMember(17, (MetaMemberFlags)0)]
        [Description("Is Developer")]
        public bool IsDeveloper { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventSessionStart()
        {
        }
    }
}