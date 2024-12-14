using Metaplay.Core.Model;
using Metaplay.Core.Json;
using System.ComponentModel;

namespace Game.Cloud.Webshop
{
    [TypeConverter(typeof(EnumStringConverter<WebshopType>))]
    [MetaSerializable]
    public enum WebshopType
    {
        Neonpay = 1
    }
}