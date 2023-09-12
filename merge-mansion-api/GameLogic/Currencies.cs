using Metaplay.Core.Json;
using System;
using System.ComponentModel;
using Metaplay.Core.Model;

namespace GameLogic
{
    [TypeConverter(typeof(EnumStringConverter<Currencies>))]
    [MetaSerializable]
    public enum Currencies
    {
        None = 0,
        Coins = 1,
        Experience = 2,
        Diamonds = 3,
        [Obsolete]
        Screws = 4,
        Energy = 5,
        EventCurrency = 6,
        SecondaryEnergy = 7,
        TertiaryEnergy = 8
    }
}