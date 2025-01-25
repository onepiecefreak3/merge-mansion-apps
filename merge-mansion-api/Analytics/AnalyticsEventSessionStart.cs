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

        [Description("How many logins happened for the player")]
        [JsonProperty("total_logins")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public int TotalLogins { get; set; }

        [JsonProperty("created")]
        [Description("When the player was created")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime CreatedAt { get; set; }

        [JsonProperty("user_first_touch_timestamp")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("When player first started playing")]
        public MetaTime FirstSession { get; set; }

        [JsonProperty("device")]
        [Description("String identifying the device")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public string Device { get; set; }

        [Description("String describing approximate location")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("location")]
        public string Location { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("How many decorations player owns")]
        [JsonProperty("decoration_count_owned")]
        public int DecorationsOwned { get; set; }

        [Description("How many decorations are visible")]
        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("decoration_count_visible")]
        public int DecorationVisible { get; set; }

        [Description("Player local time (by device) offset in hour from utc (+ or -) ")]
        [JsonProperty("player_time_offset")]
        [MetaMember(14, (MetaMemberFlags)0)]
        public MetaDuration PlayerTimeOffset { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        [Description("Attached authentication methods")]
        [JsonProperty("attached_auth_methods")]
        public string AuthenticationMethods { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        [Description("Client Version")]
        [JsonProperty("client_version")]
        public string ClientVersion { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        [JsonProperty("is_developer")]
        [Description("Is Developer")]
        public bool IsDeveloper { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventSessionStart()
        {
        }

        [JsonProperty("config_version")]
        [MetaMember(18, (MetaMemberFlags)0)]
        [Description("Config Version")]
        public string ConfigVersion { get; set; }

        [JsonProperty("server_build_version")]
        [MetaMember(19, (MetaMemberFlags)0)]
        [Description("Server Build Version")]
        public string ServerBuildVersion { get; set; }

        [MetaMember(20, (MetaMemberFlags)0)]
        [Description("OS Version")]
        [JsonProperty("os_version")]
        public string OsVersion { get; set; }
    }
}