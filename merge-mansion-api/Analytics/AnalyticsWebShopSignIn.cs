using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using System;

namespace Analytics
{
    [AnalyticsEvent(183, "WebShop Sign in step", 1, null, false, true, false)]
    public class AnalyticsWebShopSignIn : AnalyticsServersideEventBase
    {
        [JsonProperty("state")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("State of the webshop sign in")]
        public AnalyticsWebShopSignInState State;
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Has code")]
        [JsonProperty("has_code")]
        public bool HasCode;
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        public AnalyticsWebShopSignIn()
        {
        }
    }
}