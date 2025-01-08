using Metaplay.Core.Analytics;
using System;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;

namespace Analytics
{
    [AnalyticsEvent(202, "Social Media Button Clicked", 1, null, false, true, false)]
    public class SocialMediaButtonClickAnalytics : AnalyticsServersideEventBase
    {
        public override string EventDescription { get; }
        public override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("menu_name")]
        [Description("The menu where the button was clicked")]
        public string MenuName { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("ui_name")]
        [Description("The name of the clicked UI element")]
        public string UiName { get; set; }

        public SocialMediaButtonClickAnalytics()
        {
        }

        public SocialMediaButtonClickAnalytics(string menuName, string uiName)
        {
        }
    }
}