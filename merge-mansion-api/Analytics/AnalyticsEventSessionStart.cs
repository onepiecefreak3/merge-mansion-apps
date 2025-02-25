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
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("How many logins happened for the player")]
        public int TotalLogins { get; set; }

        [Description("When the player was created")]
        [JsonProperty("created")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime CreatedAt { get; set; }

        [Description("When player first started playing")]
        [JsonProperty("user_first_touch_timestamp")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public MetaTime FirstSession { get; set; }

        [JsonProperty("device")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("String identifying the device")]
        public string Device { get; set; }

        [JsonProperty("location")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("String describing approximate location")]
        public string Location { get; set; }

        [JsonProperty("decoration_count_owned")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("How many decorations player owns")]
        public int DecorationsOwned { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("decoration_count_visible")]
        [Description("How many decorations are visible")]
        public int DecorationVisible { get; set; }

        [JsonProperty("player_time_offset")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [Description("Player local time (by device) offset in hour from utc (+ or -) ")]
        public MetaDuration PlayerTimeOffset { get; set; }

        [JsonProperty("attached_auth_methods")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [Description("Attached authentication methods")]
        public string AuthenticationMethods { get; set; }

        [Description("Client Version")]
        [JsonProperty("client_version")]
        [MetaMember(16, (MetaMemberFlags)0)]
        public string ClientVersion { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        [Description("Is Developer")]
        [JsonProperty("is_developer")]
        public bool IsDeveloper { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventSessionStart()
        {
        }

        [MetaMember(18, (MetaMemberFlags)0)]
        [Description("Config Version")]
        [JsonProperty("config_version")]
        public string ConfigVersion { get; set; }

        [JsonProperty("server_build_version")]
        [Description("Server Build Version")]
        [MetaMember(19, (MetaMemberFlags)0)]
        public string ServerBuildVersion { get; set; }

        [MetaMember(20, (MetaMemberFlags)0)]
        [JsonProperty("os_version")]
        [Description("OS Version")]
        public string OsVersion { get; set; }
    }
}