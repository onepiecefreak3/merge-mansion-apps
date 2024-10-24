using System;
using Metaplay.Core.Model;
using System.Reflection;

namespace Metaplay.Core.Serialization
{
    public class MetaSerializableMember
    {
        public int TagId;
        public MetaMemberFlags Flags;
        public MemberInfo MemberInfo;
        public MethodInfo OnDeserializationFailureMethod;
        public MetaSerializableMember.SerializerGenerationOnlyInfo CodeGenInfo;
        public string Name { get; }
        public string SanitizedName { get; }
        public Type Type { get; }
        public Action<object, object> SetValue { get; }
        public Func<object, object> GetValue { get; }
        public Type DeclaringType { get; }
        public string OnDeserializationFailureMethodName { get; }

        public MetaSerializableMember(int tagId, MetaMemberFlags flags, MemberInfo memberInfo, MetaSerializableMember.SerializerGenerationOnlyInfo serializerGenerationOnlyInfo)
        {
        }

        public struct SerializerGenerationOnlyInfo
        {
        }
    }
}