using Metaplay.Core.Analytics;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using GameLogic.Area;

namespace Analytics
{
    [AnalyticsEvent(3047, "Task Group completed", 1, null, false, false, true)]
    public class TriggerTaskGroupCompleted : PlayerTriggerEvent
    {
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [Description("Completed task group")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("taskgroup_id")]
        public TaskGroupId TaskGroupId { get; set; }

        private TriggerTaskGroupCompleted()
        {
        }

        public TriggerTaskGroupCompleted(TaskGroupId taskGroupId)
        {
        }
    }
}