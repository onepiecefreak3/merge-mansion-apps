using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.GameLogic.Player.Items;
using Metaplay.GameLogic.Player.Items.Chest;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.IO;
using Metaplay.Metaplay.Core.Math;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Serialization;

namespace Metaplay.Metaplay.Generated
{
    public static class TypeSerializer
    {
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

                ResolveMetaRefs_Type(item, resolver);
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

        private static void ResolveMetaRefs_Type(object item, IGameConfigDataResolver resolver)
        {
            var taggedProperties = GetTaggedProperties(item.GetType()).Values;
            var taggedFields = GetTaggedFields(item.GetType()).Values;
            var taggedMembers = taggedProperties.Concat<MemberInfo>(taggedFields);

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

                            ResolveMetaRefs_Type(memberValue, resolver);
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

        public static object DeserializeTable(ref MetaSerializationContext context, IOReader reader, Type itemType)
        {
            var wireType = TaggedWireSerializer.ReadWireType(reader);
            TaggedWireSerializer.ExpectWireType(reader, itemType, wireType, WireDataType.ObjectTable);

            // Create dict type
            var listType = typeof(List<>);
            var result = Activator.CreateInstance(listType.MakeGenericType(itemType));

            // Deserialize table type
            DeserializeTable_Typed(ref context, reader, result);

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

        public static void Serialize(ref MetaSerializationContext context, IOWriter writer, object item)
        {
            var wireType = DetermineWireDataType(item, item.GetType());

            TaggedWireSerializer.WriteWireType(writer, wireType);
            Serialize_WireType(ref context, writer, wireType, item);
        }

        private static void DeserializeTable_Typed(ref MetaSerializationContext context, IOReader reader, object items)
        {
            var collectionSize = reader.ReadVarInt();
            if (collectionSize > context.MaxCollectionSize)
                throw new InvalidOperationException($"Invalid value collection size {collectionSize} (maximum allowed is {context.MaxCollectionSize})");

            if (collectionSize == -1)
                return;

            var listType = items.GetType().GetGenericArguments().FirstOrDefault();
            var addMethod = items.GetType().GetMethod(nameof(IList.Add));

            for (var i = 0; i < collectionSize; i++)
            {
#if DEBUG
                Console.Write($"\r{i:00000}");
#endif

                var item = Activator.CreateInstance(listType);
                Deserialize_Members(ref context, reader, item);

                addMethod.Invoke(items, new[] { item });
            }
        }

        private static void Deserialize_Members(ref MetaSerializationContext context, IOReader reader, object outValue)
        {
            var taggedProperties = GetTaggedProperties(outValue.GetType());
            var taggedFields = GetTaggedFields(outValue.GetType());

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

        private static void Serialize_Members(ref MetaSerializationContext context, IOWriter writer, object item)
        {
            var taggedProperties = GetTaggedProperties(item.GetType()).Select(x => (x.Key, x.Value.GetValue(item), x.Value.PropertyType));
            var taggedFields = GetTaggedFields(item.GetType()).Select(x => (x.Key, x.Value.GetValue(item), x.Value.FieldType));
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
            //if (item is IMetaRef metaRef)
            //{
            //    Serialize_MetaRef(ref context, writer, metaRef);
            //    return;
            //}

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
                    var deriveId = messageAttribute?.TypeCode ?? (serializeAttribute?.DeriveId ?? -1);

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

                case WireDataType.Struct:
                    value = Activator.CreateInstance(memberType, true);
                    Deserialize_Members(ref context, reader, value);
                    break;

                // Classes and Nullable<T> where T : struct
                case WireDataType.NullableStruct:
                    var hasValue = reader.ReadVarInt();
                    if (hasValue == 0)
                        break;

                    if (memberType.IsGenericType && memberType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        value = Activator.CreateInstance(memberType.GenericTypeArguments[0], true);
                    else
                        value = Activator.CreateInstance(memberType, true);

                    Deserialize_Members(ref context, reader, value);
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
                        targetTypes.FirstOrDefault(x => x.GetCustomAttribute<MetaSerializableDerivedAttribute>().DeriveId == deriveId);
                    if (targetType == null)
                        throw new InvalidOperationException($"Unknown derivative {deriveId} for type {memberType.FullName}.");

                    value = Activator.CreateInstance(targetType, true);
                    Deserialize_Members(ref context, reader, value);
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
            var metaRefType = type.GetGenericArguments().FirstOrDefault();

            Deserialize_WireType(ref context, reader, wireType, metaRefType, out var metaRefKey);

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

            var listType = collectionType.GetGenericArguments().FirstOrDefault();
            var addMethod = collectionType.GetMethod(nameof(IList.Add));

            var listWireType = TaggedWireSerializer.ReadWireType(reader);

            outValue = Activator.CreateInstance(collectionType);
            for (var i = 0; i < collectionSize; i++)
            {
                Deserialize_WireType(ref context, reader, listWireType, listType, out var item);
                addMethod.Invoke(outValue, new[] { item });
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

        private static IDictionary<int, PropertyInfo> GetTaggedProperties(Type type)
        {
            var result = new Dictionary<int, PropertyInfo>();

            var flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            foreach (var property in type.GetProperties(flags))
            {
                var customAttribute = property.GetCustomAttribute<MetaMemberAttribute>();
                if (customAttribute == null)
                    continue;

                result[customAttribute.TagId] = property;
            }

            return result;
        }

        private static IDictionary<int, FieldInfo> GetTaggedFields(Type type)
        {
            var result = new Dictionary<int, FieldInfo>();

            var flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            foreach (var field in type.GetFields(flags))
            {
                var customAttribute = field.GetCustomAttribute<MetaMemberAttribute>();
                if (customAttribute == null)
                    continue;

                result[customAttribute.TagId] = field;
            }

            return result;
        }
    }
}
