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
        [Description("State of the webshop sign in")]
        [JsonProperty("state")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public AnalyticsWebShopSignInState State;
        [JsonProperty("has_code")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Has code")]
        public bool HasCode;
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        public AnalyticsWebShopSignIn()
        {
        }
    }
}