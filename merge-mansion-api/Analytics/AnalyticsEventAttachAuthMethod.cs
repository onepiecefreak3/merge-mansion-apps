using Metaplay.Core.Analytics;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [AnalyticsEvent(120, "Attach authentication method", 1, null, false, true, false)]
    public class AnalyticsEventAttachAuthMethod : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Platform whose auth method was attached")]
        [JsonProperty("platform")]
        public string Platform { get; set; }

        [Description("Attached authentication methods")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("attached_auth_methods")]
        public string AuthenticationMethods { get; set; }

        [JsonProperty(PropertyName = "auth_status", DefaultValueHandling = (DefaultValueHandling)0)]
        public string AuthStatus { get; }
        public override string EventDescription { get; }

        public AnalyticsEventAttachAuthMethod()
        {
        }

        public AnalyticsEventAttachAuthMethod(string platform, string authenticationMethods)
        {
        }
    }
}