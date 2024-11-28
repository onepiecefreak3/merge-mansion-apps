using Metaplay.Core.Model;
using Metaplay.Core.Json;
using System;
using System.ComponentModel;

namespace GameLogic
{
    [MetaSerializable]
    [TypeConverter(typeof(EnumStringConverter<LocalizationLanguageMetacore>))]
    public enum LocalizationLanguageMetacore
    {
        English = 0,
        French = 1,
        German = 2,
        Spanish = 3,
        Italian = 4,
        Portuguese = 5,
        Russian = 6,
        Japanese = 7,
        Korean = 8
    }
}