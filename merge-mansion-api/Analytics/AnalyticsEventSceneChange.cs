using Metaplay.Core.Analytics;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using GameLogic;
using Metaplay.Core.Math;
using System;

namespace Analytics
{
    [AnalyticsEvent(185, "Scene change", 1, null, false, true, false)]
    public class AnalyticsEventSceneChange : AnalyticsServersideEventBase
    {
        [Description("ID of the scene from where transition is happening")]
        [JsonProperty("scene_from")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public LocationId SceneFrom;
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("scene_to")]
        [Description("ID of the scene to where transition is happening")]
        public LocationId SceneTo;
        [Description("duration of the loading in seconds")]
        [JsonProperty("scene_loaded")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public F64 SceneLoaded;
        public override string EventDescription { get; }
        public override AnalyticsEventType EventType { get; }

        public AnalyticsEventSceneChange()
        {
        }

        public AnalyticsEventSceneChange(LocationId sceneFrom, LocationId sceneTo, F64 sceneLoaded)
        {
        }
    }
}