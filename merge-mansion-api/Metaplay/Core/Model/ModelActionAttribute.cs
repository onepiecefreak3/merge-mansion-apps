using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage((AttributeTargets)4, AllowMultiple = false, Inherited = false)]
    public class ModelActionAttribute : Attribute, ISerializableTypeCodeProvider, ISerializableFlagsProvider
    {
        public int TypeCode { get; }
        public MetaSerializableFlags ExtraFlags { get; }

        public ModelActionAttribute(int typeCode)
        {
        }
    }
}