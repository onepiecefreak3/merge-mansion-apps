using System;

namespace Metaplay.Core.Serialization
{
    public class MetaDeserializationConvertFromConcreteDerivedTypeAttribute : MetaDeserializationConverterAttributeBase
    {
        private Type _concreteType;
        public MetaDeserializationConvertFromConcreteDerivedTypeAttribute(Type concreteType)
        {
        }
    }
}