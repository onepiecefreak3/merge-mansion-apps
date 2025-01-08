using Metaplay.Core.Model;
using Metaplay.Core.Json;
using System.ComponentModel;

namespace Game.Cloud.Webshop
{
    [MetaSerializable]
    [TypeConverter(typeof(EnumStringConverter<WebshopType>))]
    public enum WebshopType
    {
        Neonpay = 1
    }
}