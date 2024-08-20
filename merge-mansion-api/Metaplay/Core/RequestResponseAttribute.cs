using System;
using Metaplay.Core.Model;

namespace Metaplay.Core
{
    [AttributeUsage((AttributeTargets)4)]
    public class RequestResponseAttribute : Attribute, ISerializableFlagsProvider
    {
        public MetaSerializableFlags ExtraFlags { get; }

        public RequestResponseAttribute()
        {
        }
    }
}