using System;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Message
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RequestResponseAttribute : Attribute, ISerializableFlagsProvider
    {
        public MetaSerializableFlags ExtraFlags => MetaSerializableFlags.ImplicitMembers;
    }
}
