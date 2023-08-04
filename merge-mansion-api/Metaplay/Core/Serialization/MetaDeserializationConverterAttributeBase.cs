using System;

namespace Metaplay.Core.Serialization
{
    [AttributeUsage((AttributeTargets)1036, AllowMultiple = true)]
    public abstract class MetaDeserializationConverterAttributeBase : Attribute
    {
        protected MetaDeserializationConverterAttributeBase()
        {
        }
    }
}