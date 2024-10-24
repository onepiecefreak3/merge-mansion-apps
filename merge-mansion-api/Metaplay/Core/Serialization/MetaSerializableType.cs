using System;
using System.Collections.Generic;
using System.Reflection;

namespace Metaplay.Core.Serialization
{
    public class MetaSerializableType
    {
        public Type Type { get; }
        public string Name { get; }
        public bool UsesImplicitMembers { get; set; }
        public bool UsesConstructorDeserialization { get; set; }
        public bool IsPublic { get; set; }
        public WireDataType WireType { get; }
        public bool HasSerializableAttribute { get; }
        public int TypeCode { get; set; }
        public List<MetaSerializableMember> Members { get; set; }
        public Dictionary<int, MetaSerializableMember> MemberByTagId { get; set; }
        public Dictionary<string, MetaSerializableMember> MemberByName { get; set; }
        public List<MetaSerializableMember> ConstructorInitializedMembers { get; set; }
        public ConstructorInfo DeserializationConstructor { get; set; }
        public Dictionary<int, object> ConstructorParameterValues { get; set; }
        public Dictionary<int, Type> DerivedTypes { get; set; }
        public List<MethodInfo> OnDeserializedMethods { get; set; }
        public object ConfigNullSentinelKey { get; set; }
        public MetaDeserializationConverter[] DeserializationConverters { get; set; }
        public bool IsEnum { get; }
        public bool IsCollection { get; }
        public bool IsConcreteObject { get; }
        public bool IsObject { get; }
        public bool IsTuple { get; }
        public bool IsAbstract { get; }
        public bool IsGameConfigData { get; }
        public bool IsGameConfigDataContent { get; }
        public bool IsMetaRef { get; }
        public bool IsSystemNullable { get; }

        public MetaSerializableType(Type type, WireDataType wireType, bool hasSerializableAttribute)
        {
        }
    }
}