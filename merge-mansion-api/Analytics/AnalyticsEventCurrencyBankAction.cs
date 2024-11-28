using Metaplay.Core.Analytics;
using System.ComponentModel;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using GameLogic.Banks;
using System;
using Metaplay.Core.Math;
using System.Collections.Generic;
using Metaplay.Core.Player;
using GameLogic;

namespace Analytics
{
    [AnalyticsEvent(159, "Currency Bank action", 1, null, true, true, false)]
    public class AnalyticsEventCurrencyBankAction : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("bank_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Currency Bank Id from config")]
        public CurrencyBankId CurrencyBankId { get; set; }

        [Description("Threshold value for this stash")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("bank_threshold_value")]
        public int Threshold { get; set; }

        [Description("Max value for the stash")]
        [JsonProperty("bank_max_value")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public int MaxValue { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("bank_multiplier")]
        [Description("Multiplier")]
        public F64 Multiplier { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Currency Bank Action")]
        [JsonProperty("bank_action")]
        public CurrencyBankAction Action { get; set; }

        [JsonProperty("bank_action_trigger")]
        [Description("Id of the source that is causing the action")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public string TriggerId { get; set; }

        [JsonProperty("bank_resource_type")]
        [Description("Currency Type deposit / withdrawn from the bank")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public Currencies CurrencyType { get; set; }

        [JsonProperty("bank_resource_amount")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("How much resource was used in the action / how much resource was withdrawn")]
        public int Amount { get; set; }

        [Description("Change of points introduced by the action")]
        [JsonProperty("bank_points_amount")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public int Points { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Current amount of points after the action has been performed")]
        [JsonProperty("bank_amount_status")]
        public int AmountTotal { get; set; }

        [JsonProperty("bank_timer")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [Description("Current status of the timer")]
        public double StashTimer { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("Duration hidden in hours")]
        [JsonProperty("bank_duration_hidden")]
        public double DurationHidden { get; set; }

        [Description("Segments")]
        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("segments")]
        public List<PlayerSegmentId> Segments { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        [JsonProperty("bank_action_trigger_type")]
        [Description("Bank action trigger type, for example Task")]
        public CurrencyBankTriggerType TriggerType { get; set; }

        [JsonProperty("activation_id")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [Description("Unique id for this players activation")]
        public string ActivationId { get; set; }

        [JsonProperty("bank_duration_not_full")]
        [MetaMember(16, (MetaMemberFlags)0)]
        [Description("Duration bank not full")]
        public double DurationNotFull { get; set; }

        [JsonProperty("bank_duration_full")]
        [MetaMember(17, (MetaMemberFlags)0)]
        [Description("Max value of the timer")]
        public double DurationFull { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventCurrencyBankAction()
        {
        }

        public AnalyticsEventCurrencyBankAction(CurrencyBankId currencyBankId, int threshold, int maxValue, F64 multiplier, CurrencyBankAction action, string triggerId, Currencies currencyType, int amount, int points, int amountTotal, double stashTimer, double durationHidden, double durationNotFull, double durationFull, List<PlayerSegmentId> segments, CurrencyBankTriggerType triggerType, string activationId)
        {
        }
    }
}