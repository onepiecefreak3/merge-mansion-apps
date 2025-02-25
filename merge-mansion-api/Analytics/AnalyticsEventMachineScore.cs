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
    [AnalyticsEventKeywords(new string[] { "event", "task" })]
    [AnalyticsEvent(190, "Mystery Machine score at end of run", 1, null, true, true, false)]
    public class AnalyticsEventMachineScore : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("machine_event_instance")]
        [Description("Event instance number, increments per event instance. Specific to the player's instances. See machine_event_instance_id for global id.")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public int MachineEventInstance { get; set; }

        [JsonProperty("run_number")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Run number, increments every time machine is started")]
        public int RunNumber { get; set; }

        [JsonProperty("score")]
        [Description("Score reached during the run")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public int Score { get; set; }

        [Description("Permanent (machine level-based) score multiplier")]
        [JsonProperty("permanent_multiplier")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public double PermanentMultiplier { get; set; }

        [JsonProperty("temporary_multiplier")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Temporary (run-based) score multiplier")]
        public double TemporaryMultiplier { get; set; }

        [JsonProperty("heat_level")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Heat level reached during the run")]
        public int HeatLevel { get; set; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("items_spawned")]
        public Dictionary<string, int> ItemsSpawned { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("diamonds_spent_on_special_items")]
        public Dictionary<string, int> DiamondsSpentOnSpecialItems { get; set; }

        [JsonProperty("battery_spent_on_special_items")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        public Dictionary<string, int> BatterySpentOnSpecialItems { get; set; }

        [Description("String describing the context of the receiving action")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("context")]
        public string Context { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        [JsonProperty("number_of_taps")]
        [Description("Number of spawn taps during the run")]
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

        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("MysteryMachine Energy Remaining")]
        [JsonProperty("mysterymachine_energy_remaining")]
        public int MysteryMachineEnergyRemaining { get; set; }

        public AnalyticsEventMachineScore(int machineEventInstance, int runNumber, int score, F64 permanentMultiplier, F64 temporaryMultiplier, int heatLevel, Dictionary<string, int> itemsSpawned, Dictionary<string, int> diamondsSpentOnSpecialItems, Dictionary<string, int> batterySpentOnSpecialItems, AnalyticsContext context, int numberOfTaps, string startTime, int mysteryMachineEnergyRemaining)
        {
        }

        [MetaMember(14, (MetaMemberFlags)0)]
        [JsonProperty("diamonds_spent_on_machine_energy")]
        public int DiamondsSpentOnMachineEnergy { get; set; }

        [JsonProperty("total_diamonds_spent")]
        [MetaMember(15, (MetaMemberFlags)0)]
        public int TotalDiamondsSpent { get; set; }

        public AnalyticsEventMachineScore(int machineEventInstance, int runNumber, int score, F64 permanentMultiplier, F64 temporaryMultiplier, int heatLevel, Dictionary<string, int> itemsSpawned, Dictionary<string, int> diamondsSpentOnSpecialItems, Dictionary<string, int> batterySpentOnSpecialItems, AnalyticsContext context, int numberOfTaps, string startTime, int mysteryMachineEnergyRemaining, int diamondsSpentOnMachineEnergy)
        {
        }

        [JsonProperty("leaderboard_position", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(16, (MetaMemberFlags)0)]
        [Description("Position of player on the leaderboard after the run. Only sent if the run was a new high score and the event is using a leaderboard. Null in case not or the leaderboard request fails.")]
        public int? LeaderboardPosition { get; set; }

        [Description("Global instance id of the event. Can be used to track the same event across different players.")]
        [MetaMember(17, (MetaMemberFlags)0)]
        [JsonProperty("machine_event_instance_id")]
        public string MachineEventInstanceId { get; set; }

        public AnalyticsEventMachineScore(int machineEventInstance, string machineEventInstanceId, int runNumber, int score, F64 permanentMultiplier, F64 temporaryMultiplier, int heatLevel, Dictionary<string, int> itemsSpawned, Dictionary<string, int> diamondsSpentOnSpecialItems, Dictionary<string, int> batterySpentOnSpecialItems, AnalyticsContext context, int numberOfTaps, string startTime, int mysteryMachineEnergyRemaining, int diamondsSpentOnMachineEnergy)
        {
        }
    }
}