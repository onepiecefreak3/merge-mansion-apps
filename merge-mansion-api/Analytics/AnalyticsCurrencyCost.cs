using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace Analytics
{
    [MetaSerializable]
    public class AnalyticsCurrencyCost
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("currency_code")]
        [Description("Code of the currency used for purchase")]
        public string CurrencyCode { get; set; }

        [Description("Amount of the currency used for purchase")]
        [JsonProperty("amount")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public double Amount { get; set; }

        public AnalyticsCurrencyCost()
        {
        }

        public AnalyticsCurrencyCost(string currencyCode, double amount)
        {
        }
    }
}