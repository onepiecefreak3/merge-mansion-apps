using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using merge_mansion_api;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.IO;
using Metaplay.Core.Math;
using Metaplay.Core.Model;
using Metaplay.Core.Serialization;

namespace Metaplay.Generated
{
    public static class TypeSerializer
    {
        #region Cache

        private static readonly Type ListType = typeof(List<>);

        private static readonly IDictionary<Type, IDictionary<int, PropertyInfo>> _properties;
        private static readonly IDictionary<Type, IDictionary<int, FieldInfo>> _fields;

        static TypeSerializer()
        {
            var assembly = typeof(TypeSerializer).Assembly;
            var serializableTypes = assembly.GetTypes().Where(t => t.GetCustomAttribute<MetaSerializableAttribute>() != null);

            _properties = new Dictionary<Type, IDictionary<int, PropertyInfo>>();
            _fields = new Dictionary<Type, IDictionary<int, FieldInfo>>();

            foreach (var serializableType in serializableTypes)
            {
                GetTaggedMembers(serializableType,out var taggedFields, out var taggedProperties);

                _fields[serializableType] = taggedFields;
                _properties[serializableType] = taggedProperties;
            }
        }

        #endregion

        #region MetaRefs

        public static void ResolveMetaRefs_List(IList list, IGameConfigDataResolver resolver)
        {
            if (list == null)
                return;

            for (var i = 0; i < list.Count; i++)
            {
                var item = list[i];

                if (item is IMetaRef metaRef)
                {
                    list[i] = ResolveMetaRef(metaRef, resolver);
                    continue;
                }

                ResolveMetaRefs_Type(item.GetType(), item, resolver);
            }
        }

        public static void ResolveMetaRefs_Dictionary(IDictionary dict, IGameConfigDataResolver resolver)
        {
            if (dict == null)
                return;

            var setItemMethod = dict.GetType().GetProperty("Item");

            foreach (var pair in dict)
            {
                var key = pair.GetType().GetProperty("Key").GetValue(pair);
                var value = pair.GetType().GetProperty("Value").GetValue(pair);

                if (value is IMetaRef metaRef)
                {
                    var resolved = ResolveMetaRef(metaRef, resolver);
                    setItemMethod.SetValue(dict, resolved, new[] { key });
                }
            }
        }

        public static void ResolveMetaRefs_Type(Type type, object item, IGameConfigDataResolver resolver)
        {
            GetTaggedMembers(type, out var taggedFields, out var taggedProperties);
            var taggedMembers = taggedProperties.Values.Concat<MemberInfo>(taggedFields.Values);

            foreach (var member in taggedMembers)
            {
                var memberType = member is PropertyInfo pi ? pi.PropertyType : (member as FieldInfo).FieldType;
                var memberValue = member is PropertyInfo pi1 ? pi1.GetValue(item) : (member as FieldInfo).GetValue(item);

                if (!typeof(IMetaRef).IsAssignableFrom(memberType))
                {
                    if (!typeof(IList).IsAssignableFrom(memberType))
                    {
                        if (!typeof(IDictionary).IsAssignableFrom(memberType))
                        {
                            if (!(memberValue?.GetType().IsClass ?? false) || memberType == typeof(string))
                                continue;

                            ResolveMetaRefs_Type(memberValue.GetType(), memberValue, resolver);
                            continue;
                        }

                        ResolveMetaRefs_Dictionary((IDictionary)memberValue, resolver);
                        continue;
                    }

                    ResolveMetaRefs_List((IList)memberValue, resolver);
                    continue;
                }

                var resolvedValue = ResolveMetaRef((IMetaRef)memberValue, resolver);
                if (member is PropertyInfo pi2)
                    pi2.SetValue(item, resolvedValue);
                else
                    (member as FieldInfo).SetValue(item, resolvedValue);
            }
        }

        private static IMetaRef ResolveMetaRef(IMetaRef metaRef, IGameConfigDataResolver resolver)
        {
            var createResolveMethod = metaRef.GetType().GetMethod("CreateResolved");
            return (IMetaRef)createResolveMethod?.Invoke(metaRef, new object[] { resolver });
        }

        #endregion

        #region Deserialize

        public static object DeserializeTable(ref MetaSerializationContext context, IOReader reader, Type elementType)
        {
            var wireType = TaggedWireSerializer.ReadWireType(reader);
            TaggedWireSerializer.ExpectWireType(reader, elementType, wireType, WireDataType.ObjectTable);

            // Create dict type
            var genericListType = ListType.MakeGenericType(elementType);
            var result = (IList)Activator.CreateInstance(genericListType);

            // Deserialize table type
            DeserializeTable_Typed(ref context, reader, result, elementType);

            return result;
        }

        public static object Deserialize(ref MetaSerializationContext context, IOReader reader, Type itemType)
        {
            var wireType = TaggedWireSerializer.ReadWireType(reader);
            if (wireType == WireDataType.EndStruct)
                return null;

            Deserialize_WireType(ref context, reader, wireType, itemType, out var value);

            return value;
        }

        private static void DeserializeTable_Typed(ref MetaSerializationContext context, IOReader reader, IList items, Type elementType)
        {
            var collectionSize = reader.ReadVarInt();
            if (collectionSize > context.MaxCollectionSize)
                throw new InvalidOperationException($"Invalid value collection size {collectionSize} (maximum allowed is {context.MaxCollectionSize})");

            if (collectionSize == -1)
                return;

            for (var i = 0; i < collectionSize; i++)
            {
                DebugTools.WriteIndex(elementType.Name, i);

                var item = Activator.CreateInstance(elementType);
                Deserialize_Members(ref context, reader, item, elementType);

                items.Add(item);
            }
        }

        private static void Deserialize_Members(ref MetaSerializationContext context, IOReader reader, object outValue, Type valueType)
        {
            //if (!_properties.TryGetValue(valueType, out var taggedProperties))
            //    throw new InvalidOperationException($"No properties found for type {valueType.Name}.");
            //if (!_fields.TryGetValue(valueType, out var taggedFields))
            //    throw new InvalidOperationException($"No fields found for type {valueType.Name}.");

            GetTaggedMembers(outValue.GetType(), out var taggedFields, out var taggedProperties);

            do
            {
                var wireType = TaggedWireSerializer.ReadWireType(reader);
                if (wireType == WireDataType.EndStruct)
                    break;

                var tagId = TaggedWireSerializer.ReadTagId(reader);
                if (tagId <= 0)
                {
                    TaggedWireSerializer.SkipWireType(reader, wireType);
                    continue;
                }

                if (!taggedProperties.ContainsKey(tagId) && !taggedFields.ContainsKey(tagId))
                {
                    //throw new InvalidOperationException($"Read tagId {tagId} is not part of type {outValue.GetType().Name}");

                    TaggedWireSerializer.SkipWireType(reader, wireType);
                    continue;
                }

                if (taggedProperties.ContainsKey(tagId))
                {
                    var property = taggedProperties[tagId];

                    Deserialize_WireType(ref context, reader, wireType, property.PropertyType, out var value);
                    property.SetValue(outValue, value);
                }
                else
                {
                    var field = taggedFields[tagId];

                    Deserialize_WireType(ref context, reader, wireType, field.FieldType, out var value1);
                    field.SetValue(outValue, value1);
                }
            } while (true);
        }

        // CUSTOM: Read value by wire type
        private static void Deserialize_WireType(ref MetaSerializationContext context, IOReader reader, WireDataType wireType, Type memberType, out object value)
        {
            value = null;

            if (typeof(IMetaRef).IsAssignableFrom(memberType))
            {
                Deserialize_MetaRef(ref context, reader, wireType, memberType, out value);
                return;
            }

            switch (wireType)
            {
                case WireDataType.Invalid:
                case WireDataType.EndStruct:
                case WireDataType.ObjectTable:
                    throw new InvalidOperationException($"Tried to read invalid type {wireType} at position {reader.Offset}");

                case WireDataType.VarInt:
                    var baseType = memberType.IsEnum ? Enum.GetUnderlyingType(memberType) : memberType;

                    if (baseType.IsAssignableTo(typeof(IDynamicEnum)))
                    {
                        Deserialize_DynamicEnum(ref context, reader, out var v);
                        value = baseType.BaseType.GetMethod("FromId").Invoke(null, new object[] { v });
                    }
                    else if (baseType == typeof(bool))
                    {
                        Deserialize_Boolean(ref context, reader, out var v);
                        value = v;
                    }
                    else if (baseType == typeof(uint))
                    {
                        Deserialize_UInt32(ref context, reader, out var v);
                        value = v;
                    }
                    else if (baseType == typeof(long))
                    {
                        Deserialize_Int64(ref context, reader, out var v);
                        value = v;
                    }
                    else if (baseType == typeof(ulong))
                    {
                        Deserialize_UInt64(ref context, reader, out var v);
                        value = v;
                    }
                    else
                    {
                        Deserialize_Int32(ref context, reader, out var v);
                        value = v;
                    }

                    if (memberType.IsEnum)
                        value = Enum.ToObject(memberType, value);

                    break;

                case WireDataType.VarInt128:
                    Deserialize_UInt128(ref context, reader, out var v5);
                    value = v5;
                    break;

                case WireDataType.NullableVarInt:
                    Deserialize_Nullable_Int32(ref context, reader, out var v4);

                    value = v4;
                    if (memberType.GenericTypeArguments[0].IsEnum)
                        value = Enum.ToObject(memberType.GenericTypeArguments[0], v4.Value);
                    break;

                case WireDataType.String:
                    Deserialize_String(ref context, reader, out var v1);

                    value = v1;
                    if (typeof(IStringId).IsAssignableFrom(memberType))
                        value = memberType.BaseType.GetMethod("FromString").Invoke(null, new[] { v1 });

                    break;

                case WireDataType.F64:
                    Deserialize_F64(ref context, reader, out var v2);
                    value = v2;
                    break;

                case WireDataType.F32:
                    Deserialize_F32(ref context, reader, out var v3);
                    value = v3;
                    break;

                case WireDataType.Float32:
                    Deserialize_Float32(ref context, reader, out var v7);
                    value = v7;
                    break;

                case WireDataType.Struct:
                    value = Activator.CreateInstance(memberType, true);
                    Deserialize_Members(ref context, reader, value, memberType);
                    break;

                // Classes and Nullable<T> where T : struct
                case WireDataType.NullableStruct:
                    var hasValue = reader.ReadVarInt();
                    if (hasValue == 0)
                        break;

                    if (memberType.IsGenericType && memberType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        memberType = memberType.GenericTypeArguments[0];

                    value = Activator.CreateInstance(memberType, true);
                    Deserialize_Members(ref context, reader, value, memberType);
                    break;

                case WireDataType.AbstractStruct:
                    var targetTypes = Assembly.GetExecutingAssembly().GetExportedTypes().Where(memberType.IsAssignableFrom);
                    targetTypes = memberType == typeof(MetaMessage) ?
                        targetTypes.Where(x => x.GetCustomAttribute<MetaMessageAttribute>() != null) :
                        targetTypes.Where(x => x.GetCustomAttribute<MetaSerializableDerivedAttribute>() != null);

                    var deriveId = reader.ReadVarInt();
                    if (deriveId == 0)
                        break;

                    var targetType = memberType == typeof(MetaMessage) ?
                        targetTypes.FirstOrDefault(x => x.GetCustomAttribute<MetaMessageAttribute>().TypeCode == deriveId) :
                        targetTypes.FirstOrDefault(x => x.GetCustomAttribute<MetaSerializableDerivedAttribute>().TypeCode == deriveId);
                    if (targetType == null)
                        throw new InvalidOperationException($"Unknown derivative {deriveId} for type {memberType.FullName}");

                    value = Activator.CreateInstance(targetType, true);
                    Deserialize_Members(ref context, reader, value, targetType);
                    break;

                case WireDataType.ValueCollection:
                    Deserialize_ValueCollection(ref context, reader, memberType, out value);
                    break;

                case WireDataType.KeyValueCollection:
                    Deserialize_KeyValueCollection(ref context, reader, memberType, out value);
                    break;

                case WireDataType.Bytes:
                    Deserialize_ByteArray(ref context, reader, out var v6);
                    value = v6;
                    break;

                default:
                    throw new InvalidOperationException($"Unknown wire type {wireType}.");
            }
        }

        // CUSTOM: Deserialize MetaRef<TItem>
        private static void Deserialize_MetaRef(ref MetaSerializationContext context, IOReader reader, WireDataType wireType, Type type, out object value)
        {
            var keyType = (Type)type.GetMethod("GetKeyType").Invoke(null, new object[] { });

            Deserialize_WireType(ref context, reader, wireType, keyType, out var metaRefKey);

            var fromMethod = type.GetMethod("FromKey");
            value = fromMethod.Invoke(null, new[] { metaRefKey });
        }

        // CUSTOM: Deserialize value collections
        private static void Deserialize_ValueCollection(ref MetaSerializationContext context, IOReader reader, Type collectionType, out object outValue)
        {
            outValue = null;

            var collectionSize = reader.ReadVarInt();
            if (collectionSize > context.MaxCollectionSize)
                throw new InvalidOperationException($"Invalid value collection size {collectionSize} (maximum allowed is {context.MaxCollectionSize})");

            if (collectionSize == -1)
                return;

            var listWireType = TaggedWireSerializer.ReadWireType(reader);

            if (collectionType.IsArray)
            {
                var arrayType = collectionType.GetElementType();
                var arrayValue = Array.CreateInstance(arrayType, collectionSize);

                for (var i = 0; i < collectionSize; i++)
                {
                    Deserialize_WireType(ref context, reader, listWireType, arrayType, out var item);
                    arrayValue.SetValue(item, i);
                }

                outValue = arrayValue;
            }
            else
            {
                var listType = collectionType.GetGenericArguments().FirstOrDefault() ?? collectionType.GetElementType();
                var addMethod = collectionType.GetMethod(nameof(IList.Add));

                outValue = Activator.CreateInstance(collectionType);
                for (var i = 0; i < collectionSize; i++)
                {
                    Deserialize_WireType(ref context, reader, listWireType, listType, out var item);
                    addMethod.Invoke(outValue, new[] { item });
                }
            }
        }

        // CUSTOM: Deserialize dictionaries
        private static void Deserialize_KeyValueCollection(ref MetaSerializationContext context, IOReader reader, Type collectionType, out object outValue)
        {
            outValue = null;

            var dictCount = reader.ReadVarInt();
            if (dictCount > context.MaxCollectionSize)
                throw new InvalidOperationException($"Invalid key value collection size {dictCount} (maximum allowed is {context.MaxCollectionSize})");

            if (dictCount == -1)
                return;

            var addMethod = collectionType.GetMethod(nameof(IList.Add));
            var dictTypes = collectionType.GetGenericArguments().Take(2).ToArray();

            var keyWireType = TaggedWireSerializer.ReadWireType(reader);
            var valueWireType = TaggedWireSerializer.ReadWireType(reader);

            outValue = Activator.CreateInstance(collectionType);
            for (var i = 0; i < dictCount; i++)
            {
                Deserialize_WireType(ref context, reader, keyWireType, dictTypes[0], out var key);
                Deserialize_WireType(ref context, reader, valueWireType, dictTypes[1], out var v4);

                addMethod.Invoke(outValue, new[] { key, v4 });
            }
        }

        private static void Deserialize_ByteArray(ref MetaSerializationContext context, IOReader reader, out byte[] value)
        {
            value = reader.ReadByteString(context.MaxByteArraySize);
        }

        private static void Deserialize_Boolean(ref MetaSerializationContext context, IOReader reader, out bool value)
        {
            value = reader.ReadByte() == 1;
        }

        private static void Deserialize_DynamicEnum(ref MetaSerializationContext context, IOReader reader, out int value)
        {
            value = reader.ReadVarInt();
        }

        private static void Deserialize_Int32(ref MetaSerializationContext context, IOReader reader, out int value)
        {
            value = reader.ReadVarInt();
        }

        private static void Deserialize_UInt32(ref MetaSerializationContext context, IOReader reader, out uint value)
        {
            value = reader.ReadVarUInt();
        }

        private static void Deserialize_Int64(ref MetaSerializationContext context, IOReader reader, out long value)
        {
            value = reader.ReadVarLong();
        }

        private static void Deserialize_UInt64(ref MetaSerializationContext context, IOReader reader, out ulong value)
        {
            value = reader.ReadVarULong();
        }

        private static void Deserialize_UInt128(ref MetaSerializationContext context, IOReader reader, out UInt128 value)
        {
            value = reader.ReadVarUInt128();
        }

        private static void Deserialize_Nullable_Int32(ref MetaSerializationContext context, IOReader reader, out int? value)
        {
            var flag = reader.ReadVarInt();
            value = flag == 0 ? 0 : reader.ReadVarInt();
        }

        private static void Deserialize_String(ref MetaSerializationContext context, IOReader reader, out string value)
        {
            value = reader.ReadString(context.MaxStringSize);
        }

        private static void Deserialize_F64(ref MetaSerializationContext context, IOReader reader, out F64 outValue)
        {
            outValue = reader.ReadF64();
        }

        private static void Deserialize_F32(ref MetaSerializationContext context, IOReader reader, out F32 outValue)
        {
            outValue = reader.ReadF32();
        }

        private static void Deserialize_Float32(ref MetaSerializationContext context, IOReader reader, out float outValue)
        {
            outValue = reader.ReadFloat();
        }

        #endregion

        #region Serialize

        public static void Serialize(ref MetaSerializationContext context, IOWriter writer, object item)
        {
            var wireType = DetermineWireDataType(item, item.GetType());

            TaggedWireSerializer.WriteWireType(writer, wireType);
            Serialize_WireType(ref context, writer, wireType, item);
        }

        private static void Serialize_Members(ref MetaSerializationContext context, IOWriter writer, object item)
        {
            GetTaggedMembers(item.GetType(), out var fields, out var properties);

            var taggedFields = fields.Select(x => (x.Key, x.Value.GetValue(item), x.Value.FieldType));
            var taggedProperties = properties.Select(x => (x.Key, x.Value.GetValue(item), x.Value.PropertyType));

            var values = taggedProperties.Concat(taggedFields).OrderBy(x => x.Key);

            foreach (var value in values)
            {
                var wireType = DetermineWireDataType(value.Item2, value.Item3);

                TaggedWireSerializer.WriteWireType(writer, wireType);
                TaggedWireSerializer.WriteTagId(writer, value.Key);
                Serialize_WireType(ref context, writer, wireType, value.Item2);
            }

            TaggedWireSerializer.WriteWireType(writer, WireDataType.EndStruct);
        }

        // CUSTOM: Determines the wire data type from a given object
        private static WireDataType DetermineWireDataType(object item, Type itemType)
        {
            if (itemType.IsAssignableTo(typeof(UInt128)))
                return WireDataType.VarInt128;

            if (itemType.IsAssignableTo(typeof(string)) ||
                itemType.IsAssignableTo(typeof(IStringId)))
                return WireDataType.String;

            if (itemType.IsAssignableTo(typeof(IDictionary)))
                return WireDataType.KeyValueCollection;

            if (itemType.IsAssignableTo(typeof(IDynamicEnum)))
                return WireDataType.VarInt;

            if (itemType.GetCustomAttribute<MetaSerializableDerivedAttribute>() != null ||
                itemType.GetCustomAttribute<MetaMessageAttribute>() != null ||
                itemType.IsInterface || itemType.IsAbstract)
                return WireDataType.AbstractStruct;

            if (!itemType.IsValueType || Nullable.GetUnderlyingType(itemType) != null)
                return WireDataType.NullableStruct;

            if (itemType.IsAssignableTo(typeof(bool)) ||
                itemType.IsAssignableTo(typeof(int)) ||
                itemType.IsAssignableTo(typeof(uint)) ||
                itemType.IsAssignableTo(typeof(long)) ||
                itemType.IsAssignableTo(typeof(ulong)) ||
                itemType.IsEnum)
                return WireDataType.VarInt;

            if (itemType.IsValueType)
                return WireDataType.Struct;

            throw new InvalidOperationException($"Unknown type {item.GetType().Name} to determine wire data type.");
        }

        // CUSTOM: Write values as wire type
        private static void Serialize_WireType(ref MetaSerializationContext context, IOWriter writer, WireDataType wireType, object item)
        {
            switch (wireType)
            {
                case WireDataType.VarInt:
                    if (item.GetType().IsEnum)
                        item = Convert.ChangeType(item, Enum.GetUnderlyingType(item.GetType()));

                    if (item is IDynamicEnum)
                        Serialize_DynamicEnum(ref context, writer, (IDynamicEnum)item);
                    if (item is bool)
                        Serialize_Boolean(ref context, writer, (bool)item);
                    else if (item is long)
                        Serialize_Int64(ref context, writer, (long)item);
                    else if (item is ulong)
                        Serialize_UInt64(ref context, writer, (ulong)item);
                    else if (item is int)
                        Serialize_Int32(ref context, writer, (int)item);
                    else if (item is uint)
                        Serialize_UInt32(ref context, writer, (uint)item);
                    break;

                case WireDataType.VarInt128:
                    Serialize_UInt128(ref context, writer, (UInt128)item);
                    break;

                case WireDataType.String:
                    var value = item;
                    if (item is IStringId sId)
                        value = sId.Value;

                    Serialize_String(ref context, writer, (string)value);
                    break;

                case WireDataType.NullableStruct:
                    if (item is null)
                        writer.WriteVarInt(0);
                    else
                    {
                        writer.WriteVarInt(1);
                        Serialize_Members(ref context, writer, item);
                    }
                    break;

                case WireDataType.AbstractStruct:
                    if (item == null)
                    {
                        writer.WriteVarInt(0);
                        return;
                    }

                    var type = item.GetType();

                    var messageAttribute = type.GetCustomAttribute<MetaMessageAttribute>();
                    var serializeAttribute = type.GetCustomAttribute<MetaSerializableDerivedAttribute>();
                    var deriveId = messageAttribute?.TypeCode ?? (serializeAttribute?.TypeCode ?? -1);

                    writer.WriteVarInt(deriveId);

                    Serialize_Members(ref context, writer, item);
                    break;

                case WireDataType.Struct:
                    Serialize_Members(ref context, writer, item);
                    break;

                case WireDataType.KeyValueCollection:
                    Serialize_KeyValueCollection(ref context, writer, (IDictionary)item);
                    break;

                default:
                    throw new InvalidOperationException($"Invalid wire type {wireType} to write.");
            }
        }

        private static void Serialize_Boolean(ref MetaSerializationContext context, IOWriter writer, bool value)
        {
            writer.WriteByte((byte)(value ? 1 : 0));
        }

        private static void Serialize_DynamicEnum(ref MetaSerializationContext context, IOWriter writer, IDynamicEnum value)
        {
            writer.WriteVarInt(value.Id);
        }

        private static void Serialize_Int32(ref MetaSerializationContext context, IOWriter writer, int value)
        {
            writer.WriteVarInt(value);
        }

        private static void Serialize_UInt32(ref MetaSerializationContext context, IOWriter writer, uint value)
        {
            writer.WriteVarUInt(value);
        }

        private static void Serialize_Int64(ref MetaSerializationContext context, IOWriter writer, long value)
        {
            writer.WriteVarLong(value);
        }

        private static void Serialize_UInt64(ref MetaSerializationContext context, IOWriter writer, ulong value)
        {
            writer.WriteVarULong(value);
        }

        private static void Serialize_UInt128(ref MetaSerializationContext context, IOWriter writer, UInt128 inValue)
        {
            writer.WriteVarUInt128(inValue);
        }

        private static void Serialize_String(ref MetaSerializationContext context, IOWriter writer, string inValue)
        {
            writer.WriteString(inValue);
        }

        // CUSTOM: Serialize dictionaries
        private static void Serialize_KeyValueCollection(ref MetaSerializationContext context, IOWriter writer, IDictionary collection)
        {
            // Write count
            var count = collection.Count;
            if (count > context.MaxCollectionSize)
                throw new InvalidOperationException($"Invalid key value collection size {count} (maximum allowed is {context.MaxCollectionSize})");

            writer.WriteVarInt(count);

            // Collect meta data
            var dictTypes = collection.GetType().GetGenericArguments().Take(2).ToArray();

            var keyWireType = DetermineWireDataType(null, dictTypes[0]);
            var valueWireType = DetermineWireDataType(null, dictTypes[1]);

            // Write dictionary types
            TaggedWireSerializer.WriteWireType(writer, keyWireType);
            TaggedWireSerializer.WriteWireType(writer, valueWireType);

            // Write dictionary
            foreach (var key in collection.Keys)
            {
                var value = collection[key];

                Serialize_WireType(ref context, writer, keyWireType, key);
                Serialize_WireType(ref context, writer, valueWireType, value);
            }
        }

        #endregion

        #region Support

        private static void GetTaggedMembers(Type type, out IDictionary<int, FieldInfo> taggedFields, out IDictionary<int, PropertyInfo> taggedProperties)
        {
            var implicitMembers = type.GetCustomAttribute<MetaImplicitMembersRangeAttribute>();
            var startIndex = implicitMembers?.StartIndex ?? 0;

            taggedFields = GetTaggedFields(type, implicitMembers != null, ref startIndex);
            taggedProperties = GetTaggedProperties(type, implicitMembers != null, ref startIndex);
        }

        private static IDictionary<int, FieldInfo> GetTaggedFields(Type type, bool isImplicit, ref int startIndex)
        {
            var result = new Dictionary<int, FieldInfo>();

            var flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            foreach (var field in type.GetFields(flags))
            {
                if (isImplicit)
                {
                    result[startIndex++] = field;
                    continue;
                }

                var customAttribute = field.GetCustomAttribute<MetaMemberAttribute>();
                if (customAttribute == null)
                    continue;

                result[customAttribute.TagId] = field;
            }

            return result;
        }

        private static IDictionary<int, PropertyInfo> GetTaggedProperties(Type type, bool isImplicit, ref int startIndex)
        {
            var result = new Dictionary<int, PropertyInfo>();

            var flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            foreach (var property in type.GetProperties(flags))
            {
                if (isImplicit)
                {
                    result[startIndex++] = property;
                    continue;
                }

                var customAttribute = property.GetCustomAttribute<MetaMemberAttribute>();
                if (customAttribute == null)
                    continue;

                result[customAttribute.TagId] = property;
            }

            return result;
        }

        #endregion
    }
}
