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

        [Description("The menu where the button was clicked")]
        [JsonProperty("menu_name")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string MenuName { get; set; }

        [JsonProperty("ui_name")]
        [MetaMember(2, (MetaMemberFlags)0)]
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