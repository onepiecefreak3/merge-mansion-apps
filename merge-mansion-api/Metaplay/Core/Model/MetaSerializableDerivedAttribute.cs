using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage((AttributeTargets)4)]
    public class MetaSerializableDerivedAttribute : Attribute, ISerializableTypeCodeProvider
    {
        public MetaSerializableDerivedAttribute(int deriveDeriveId)
        {
            TypeCode = deriveDeriveId;
        }

        public int TypeCode { get; set; }
    }
}