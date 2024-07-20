using Metaplay.Core.Analytics;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Metaplay.Core.Math;
using GameLogic.Player;

namespace Analytics
{
    [AnalyticsEvent(190, "Mystery Machine score at end of run", 1, null, true, true, false)]
    public class AnalyticsEventMachineScore : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Event instance number, increments per event instance")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("machine_event_instance")]
        public int MachineEventInstance { get; set; }

        [Description("Run number, increments every time machine is started")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("run_number")]
        public int RunNumber { get; set; }

        [JsonProperty("score")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Score reached during the run")]
        public int Score { get; set; }

        [JsonProperty("permanent_multiplier")]
        [Description("Permanent (machine level-based) score multiplier")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public double PermanentMultiplier { get; set; }

        [Description("Temporary (run-based) score multiplier")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("temporary_multiplier")]
        public double TemporaryMultiplier { get; set; }

        [Description("Heat level reached during the run")]
        [JsonProperty("heat_level")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public int HeatLevel { get; set; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("items_spawned")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public Dictionary<string, int> ItemsSpawned { get; set; }

        [JsonProperty("diamonds_spent_on_special_items")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<string, int> DiamondsSpentOnSpecialItems { get; set; }

        [JsonProperty("battery_spent_on_special_items")]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(9, (MetaMemberFlags)0)]
        public Dictionary<string, int> BatterySpentOnSpecialItems { get; set; }

        [JsonProperty("context")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("String describing the context of the receiving action")]
        public string Context { get; set; }

        [JsonProperty("number_of_taps")]
        [Description("Number of spawn taps during the run")]
        [MetaMember(11, (MetaMemberFlags)0)]
        public int NumberOfTaps { get; set; }

        [Description("Start time of the run")]
        [JsonProperty("start_time")]
        [MetaMember(12, (MetaMemberFlags)0)]
        public string StartTime { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventMachineScore()
        {
        }

        public AnalyticsEventMachineScore(int machineEventInstance, int runNumber, int score, F64 permanentMultiplier, F64 temporaryMultiplier, int heatLevel, Dictionary<string, int> itemsSpawned, Dictionary<string, int> diamondsSpentOnSpecialItems, Dictionary<string, int> batterySpentOnSpecialItems, AnalyticsContext context, int numberOfTaps, string startTime)
        {
        }

        [JsonProperty("mysterymachine_energy_remaining")]
        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("MysteryMachine Energy Remaining")]
        public int MysteryMachineEnergyRemaining { get; set; }

        public AnalyticsEventMachineScore(int machineEventInstance, int runNumber, int score, F64 permanentMultiplier, F64 temporaryMultiplier, int heatLevel, Dictionary<string, int> itemsSpawned, Dictionary<string, int> diamondsSpentOnSpecialItems, Dictionary<string, int> batterySpentOnSpecialItems, AnalyticsContext context, int numberOfTaps, string startTime, int mysteryMachineEnergyRemaining)
        {
        }
    }
}