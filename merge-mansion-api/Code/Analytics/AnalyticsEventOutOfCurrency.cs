using Metaplay.Core.Analytics;
using Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using GameLogic;
using System;

namespace Code.Analytics
{
    [AnalyticsEvent(214, "Out of currency", 1, null, true, true, false)]
    public class AnalyticsEventOutOfCurrency : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("type")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("The feature that caused the trigger")]
        public CurrencySink Type { get; set; }

        [JsonProperty("virtual_currency_name")]
        [Description("The name of currency")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public Currencies CurrencyName { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventOutOfCurrency()
        {
        }

        public AnalyticsEventOutOfCurrency(CurrencySink type, Currencies currencyName)
        {
        }
    }
}