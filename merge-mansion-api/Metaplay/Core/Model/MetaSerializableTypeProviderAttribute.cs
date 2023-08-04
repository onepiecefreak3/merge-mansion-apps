using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage((AttributeTargets)12)]
    public class MetaSerializableTypeProviderAttribute : Attribute
    {
        public MetaSerializableTypeProviderAttribute()
        {
        }
    }
}