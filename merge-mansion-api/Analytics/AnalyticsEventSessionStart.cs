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

        [JsonProperty("total_logins")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("How many logins happened for the player")]
        public int TotalLogins { get; set; }

        [JsonProperty("created")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("When the player was created")]
        public MetaTime CreatedAt { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("When player first started playing")]
        [JsonProperty("user_first_touch_timestamp")]
        public MetaTime FirstSession { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("device")]
        [Description("String identifying the device")]
        public string Device { get; set; }

        [Description("String describing approximate location")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("location")]
        public string Location { get; set; }

        [Description("How many decorations player owns")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("decoration_count_owned")]
        public int DecorationsOwned { get; set; }

        [Description("How many decorations are visible")]
        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("decoration_count_visible")]
        public int DecorationVisible { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        [Description("Player local time (by device) offset in hour from utc (+ or -) ")]
        [JsonProperty("player_time_offset")]
        public MetaDuration PlayerTimeOffset { get; set; }

        [JsonProperty("attached_auth_methods")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [Description("Attached authentication methods")]
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

        [Description("Config Version")]
        [JsonProperty("config_version")]
        [MetaMember(18, (MetaMemberFlags)0)]
        public string ConfigVersion { get; set; }

        [JsonProperty("server_build_version")]
        [MetaMember(19, (MetaMemberFlags)0)]
        [Description("Server Build Version")]
        public string ServerBuildVersion { get; set; }

        [JsonProperty("os_version")]
        [MetaMember(20, (MetaMemberFlags)0)]
        [Description("OS Version")]
        public string OsVersion { get; set; }
    }
}