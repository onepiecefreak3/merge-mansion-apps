using Metaplay.Core.Analytics;
using System.ComponentModel;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using GameLogic.Banks;
using System;

namespace Analytics
{
    [AnalyticsEvent(162, "Currency Bank state changed", 1, null, true, true, false)]
    public class AnalyticsEventCurrencyBankStateChanged : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Currency Bank Id from config")]
        [JsonProperty("bank_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public CurrencyBankId CurrencyBankId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Threshold value for this stash")]
        [JsonProperty("state")]
        public CurrencyBankState CurrencyBankState { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("activation_id")]
        [Description("Unique id for this players activation")]
        public string ActivationId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventCurrencyBankStateChanged()
        {
        }

        public AnalyticsEventCurrencyBankStateChanged(CurrencyBankId currencyBankId, CurrencyBankState currencyBankState, string activationId)
        {
        }
    }
}