using Metaplay.Core.Model;
using Metaplay.Core.Json;
using System;
using System.ComponentModel;

namespace GameLogic
{
    [MetaSerializable]
    [TypeConverter(typeof(EnumStringConverter<DialogCharacterType>))]
    public enum DialogCharacterType
    {
        NoChange = 0,
        None = 1,
        Grandma = 2,
        Maddie = 3,
        Roddy = 4,
        AntiqueDealer = 5,
        Jackson = 6,
        Arthur = 7,
        Dog = 8,
        Jackie = 9,
        Deb = 10,
        Phone = 11,
        Holden = 12,
        Winston = 13,
        Cherry = 14,
        Pearl = 15,
        Heikki = 16,
        Victoria = 17,
        Mason = 18,
        Amy = 19,
        Emilio = 20,
        Hank = 21,
        Bruno = 22,
        Voyance = 23,
        Ash = 24,
        Sullivan = 25,
        Pet = 26
    }
}