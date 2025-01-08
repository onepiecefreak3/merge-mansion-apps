using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using Metaplay.Core;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 3, 4, 5, 6, 10, 11 })]
    [AnalyticsEvent(114, "Session start", 1, null, false, true, false)]
    public class AnalyticsEventSessionStart : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("total_logins")]
        [Description("How many logins happened for the player")]
        public int TotalLogins { get; set; }

        [JsonProperty("created")]
        [Description("When the player was created")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime CreatedAt { get; set; }

        [JsonProperty("user_first_touch_timestamp")]
        [Description("When player first started playing")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public MetaTime FirstSession { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("device")]
        [Description("String identifying the device")]
        public string Device { get; set; }

        [JsonProperty("location")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("String describing approximate location")]
        public string Location { get; set; }

        [Description("How many decorations player owns")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("decoration_count_owned")]
        public int DecorationsOwned { get; set; }

        [Description("How many decorations are visible")]
        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("decoration_count_visible")]
        public int DecorationVisible { get; set; }

        [Description("Player local time (by device) offset in hour from utc (+ or -) ")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [JsonProperty("player_time_offset")]
        public MetaDuration PlayerTimeOffset { get; set; }

        [Description("Attached authentication methods")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [JsonProperty("attached_auth_methods")]
        public string AuthenticationMethods { get; set; }

        [Description("Client Version")]
        [JsonProperty("client_version")]
        [MetaMember(16, (MetaMemberFlags)0)]
        public string ClientVersion { get; set; }

        [Description("Is Developer")]
        [JsonProperty("is_developer")]
        [MetaMember(17, (MetaMemberFlags)0)]
        public bool IsDeveloper { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventSessionStart()
        {
        }

        [JsonProperty("config_version")]
        [MetaMember(18, (MetaMemberFlags)0)]
        [Description("Config Version")]
        public string ConfigVersion { get; set; }

        [Description("Server Build Version")]
        [MetaMember(19, (MetaMemberFlags)0)]
        [JsonProperty("server_build_version")]
        public string ServerBuildVersion { get; set; }

        [MetaMember(20, (MetaMemberFlags)0)]
        [JsonProperty("os_version")]
        [Description("OS Version")]
        public string OsVersion { get; set; }
    }
}