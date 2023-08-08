using Metaplay.Core.Analytics;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [AnalyticsEvent(147, "Video playback finished", 1, null, false, true, false)]
    public class AnalyticsEventVideoPlaybackFinished : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Video key")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("video_key")]
        public string Key { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventVideoPlaybackFinished()
        {
        }

        public AnalyticsEventVideoPlaybackFinished(string key)
        {
        }
    }
}