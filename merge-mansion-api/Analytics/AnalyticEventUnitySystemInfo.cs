using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using Metaplay.Core.Debugging;
using System;

namespace Analytics
{
    [AnalyticsEvent(208, "Unity System Info", 1, null, false, true, false)]
    public class AnalyticEventUnitySystemInfo : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("system_info")]
        public UnitySystemInfo SystemInfo { get; set; }
        public override string EventDescription { get; }

        public AnalyticEventUnitySystemInfo()
        {
        }

        public AnalyticEventUnitySystemInfo(UnitySystemInfo unitySystemInfo)
        {
        }
    }
}