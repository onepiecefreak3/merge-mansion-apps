using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using Code.GameLogic.GameEvents;
using GameLogic;

namespace Analytics
{
    [MetaSerializable]
    public class GameResourceCost
    {
        [Description("Type of the currency used")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("virtual_currency_name")]
        public Currencies Currency { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Amount of the currency used")]
        [JsonProperty("value")]
        public int Amount { get; set; }

        [JsonProperty("event_currency_id")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Amount of the currency used")]
        public EventCurrencyId EventCurrencyId { get; set; }

        public GameResourceCost()
        {
        }

        public GameResourceCost(Currencies currency, int amount, EventCurrencyId eventCurrencyId)
        {
        }
    }
}