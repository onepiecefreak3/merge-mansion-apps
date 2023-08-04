using System;
using Metaplay.Core.Model;

namespace Metaplay.Core.Message
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RequestResponseAttribute : Attribute, ISerializableFlagsProvider
    {
        public MetaSerializableFlags ExtraFlags => MetaSerializableFlags.ImplicitMembers;

        public RequestResponseAttribute()
        {
        }
    }
}