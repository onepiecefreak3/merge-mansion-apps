using Metaplay.Core.Analytics;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;
using Code.GameLogic.GameEvents;
using Metaplay.Core.Math;
using GameLogic.Player;

namespace Analytics
{
    [AnalyticsEvent(190, "Mystery Machine task completed", 1, null, true, true, false)]
    public class AnalyticsEventMachineTaskCompleted : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Event instance number, increments per event instance")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("machine_event_instance")]
        public int MachineEventInstance { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Run number, increments every time machine is started")]
        [JsonProperty("run_number")]
        public int RunNumber { get; set; }

        [JsonProperty("task_id")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Id of task that was completed")]
        public string TaskId { get; set; }

        [Description("How much permanent (machine level-based) score multiplier increased")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("task_multiplier_added")]
        public double TaskMultiplierAdded { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Permanent (machine level-based) score multiplier after completing the task")]
        [JsonProperty("task_multiplier_total")]
        public double TaskMultiplierTotal { get; set; }

        [Description("How many times the recurring task has been completed, if this is a recurring task - otherwise null")]
        [JsonProperty("recurring_complete")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public int? RecurringComplete { get; set; }

        [JsonProperty("context")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("String describing the context of the receiving action")]
        public string Context { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventMachineTaskCompleted()
        {
        }

        public AnalyticsEventMachineTaskCompleted(int machineEventInstance, int runNumber, MysteryMachineTaskId taskId, F64 levelMultiplierBefore, F64 levelMultiplierAfter, int? recurringComplete, AnalyticsContext context)
        {
        }
    }
}