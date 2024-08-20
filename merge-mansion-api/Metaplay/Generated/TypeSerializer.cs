using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using GameLogic.Config;
using GameLogic.MergeChains;
using GameLogic.Player.Items;
using GameLogic.Player.Items.Production;
using GameLogic.Story;
using merge_mansion_api;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.IO;
using Metaplay.Core.Math;
using Metaplay.Core.Model;
using Metaplay.Core.Serialization;
using Newtonsoft.Json.Linq;
using static Metaplay.Core.Player.PlayerPropertyConstant;
using UInt128 = Metaplay.Core.Math.UInt128;

namespace Metaplay.Generated
{
    public static class TypeSerializer
    {
        #region Cache

        private static readonly Type ListType = typeof(List<>);
        private static readonly Type MetaRefInterface = typeof(IMetaRef);
        private static readonly Type DynamicEnumInterface = typeof(IDynamicEnum);
        private static readonly Type MetaMessageType = typeof(MetaMessage);
        private static readonly Type GameConfigDataType = typeof(GameConfigDataContent<>);
        private static readonly Type CollectionType = typeof(Collection<>);
        private static readonly Type CollectionInterfaceType = typeof(ICollection<>);

        private const string DynamicEnumFromId = "FromId";
        private const string StringIdFromString = "FromString";
        private const string MetaRefGetKeyType = "GetKeyType";
        private const string MetaRefFromKey = "FromKey";
        private const string AddItemName = "Add";

        private static readonly IDictionary<Type, IDictionary<int, PropertyInfo>> _properties;
        private static readonly IDictionary<Type, IDictionary<int, FieldInfo>> _fields;

        private static readonly IDictionary<Type, IDictionary<int, Type>> _derivableTypes;
        private static readonly IDictionary<Type, IDictionary<int, Type>> _messageTypes;

        static TypeSerializer()
        {
            _properties = new Dictionary<Type, IDictionary<int, PropertyInfo>>();
            _fields = new Dictionary<Type, IDictionary<int, FieldInfo>>();

            _derivableTypes = new Dictionary<Type, IDictionary<int, Type>>();
            _messageTypes = new Dictionary<Type, IDictionary<int, Type>>();
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
                if (item == null)
                    continue;

                if (item is IMetaRef metaRef)
                {
                    list[i] = metaRef.CreateResolved(resolver);
                    continue;
                }

                var itemType = item.GetType();
                ResolveMetaRefs_Type(itemType, item, resolver);
            }
        }

        public static void ResolveMetaRefs_Dictionary(IDictionary dict, IGameConfigDataResolver resolver)
        {
            if (dict == null)
                return;

            // Resolve keys
            var keyArray = new object[dict.Count];
            dict.Keys.CopyTo(keyArray, 0);

            foreach (var key in keyArray)
            {
                if (key is IMetaRef keyRef)
                {
                    var resolved = keyRef.CreateResolved(resolver);
                    dict[resolved] = dict[key];

                    dict.Remove(key);
                }
            }

            // Resolve values
            foreach (var key in dict.Keys)
            {
                if (dict[key] is IMetaRef metaRef)
                {
                    dict[key] = metaRef.CreateResolved(resolver);
                    continue;
                }

                var valueType = dict[key].GetType();
                ResolveMetaRefs_Type(valueType, dict[key], resolver);
            }
        }

        public static void ResolveMetaRefs_Type(Type type, object item, IGameConfigDataResolver resolver)
        {
            GetTaggedMembers(type, out var taggedFields, out var taggedProperties);
            var taggedMembers = taggedProperties.Values.Concat<MemberInfo>(taggedFields.Values);

            foreach (var member in taggedMembers)
            {
                var memberValue = member is PropertyInfo pi1 ? pi1.GetValue(item) : (member as FieldInfo)!.GetValue(item);
                if (memberValue == null)
                    continue;

                var memberType = memberValue.GetType();
                if (memberValue is not IMetaRef metaRef)
                {
                    if (memberValue is not IList list)
                    {
                        if (memberValue is not IDictionary dictionary)
                        {
                            //if (!memberType.IsClass || memberValue is not string)
                            //    continue;

                            ResolveMetaRefs_Type(memberType, memberValue, resolver);
                            continue;
                        }

                        ResolveMetaRefs_Dictionary(dictionary, resolver);
                        continue;
                    }

                    ResolveMetaRefs_List(list, resolver);
                    continue;
                }

                var resolvedValue = metaRef.CreateResolved(resolver);
                if (member is PropertyInfo pi2)
                    pi2.SetValue(item, resolvedValue);
                else
                    (member as FieldInfo)!.SetValue(item, resolvedValue);
            }
        }

        #endregion

        #region Deserialize

        public static IList DeserializeTable(ref MetaSerializationContext context, IOReader reader, Type elementType)
        {
            var wireType = TaggedWireSerializer.ReadWireType(reader);
            TaggedWireSerializer.ExpectWireType(reader, elementType, wireType, WireDataType.ObjectTable);

            Tracer.Instance.Push($"{elementType.Name}_Table");

            var table = DeserializeTable_Typed(ref context, reader, elementType);

            Tracer.Instance.Pop();

            return table;
        }

        public static object Deserialize(ref MetaSerializationContext context, IOReader reader, Type itemType)
        {
            var wireType = TaggedWireSerializer.ReadWireType(reader);
            if (wireType == WireDataType.EndStruct)
                return null;

            Deserialize_WireType(ref context, reader, wireType, itemType, out var value);

            return value;
        }

        private static IList DeserializeTable_Typed(ref MetaSerializationContext context, IOReader reader, Type elementType)
        {
            var collectionSize = reader.ReadVarInt();
            if (collectionSize > context.MaxCollectionSize)
                throw new InvalidOperationException($"Invalid value collection size {collectionSize} (maximum allowed is {context.MaxCollectionSize})");

            var listType = ListType.MakeGenericType(elementType);
            if (collectionSize == -1)
                return (IList)Activator.CreateInstance(listType);

            var items = (IList)Activator.CreateInstance(listType, collectionSize);
            for (var i = 0; i < collectionSize; i++)
            {
                DebugTools.WriteIndex(elementType.Name, i);

                Tracer.Instance.Push($"[{i}]");

                var item = Activator.CreateInstance(elementType);
                Deserialize_Members(ref context, reader, item, elementType);

                Tracer.Instance.Pop();

                items?.Add(item);
            }

            return items;
        }

        private static void Deserialize_Members(ref MetaSerializationContext context, IOReader reader, object outValue, Type valueType)
        {
            GetTaggedMembers(valueType, out var taggedFields, out var taggedProperties);

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
                    TaggedWireSerializer.SkipWireType(reader, wireType);
                    continue;
                }

                object value;
                if (taggedProperties.ContainsKey(tagId))
                {
                    var property = taggedProperties[tagId];

                    Tracer.Instance.Push(property.Name);

                    Deserialize_WireType(ref context, reader, wireType, property.PropertyType, out value);

                    Tracer.Instance.Pop();

                    property.SetValue(outValue, value);
                }
                else
                {
                    var field = taggedFields[tagId];

                    Tracer.Instance.Push(field.Name);

                    Deserialize_WireType(ref context, reader, wireType, field.FieldType, out value);

                    Tracer.Instance.Pop();

                    field.SetValue(outValue, value);
                }
            } while (true);
        }

        // CUSTOM: Read value by wire type
        private static void Deserialize_WireType(ref MetaSerializationContext context, IOReader reader, WireDataType wireType, Type memberType, out object value)
        {
            value = null;

            // Handle MetaRef
            if (MetaRefInterface.IsAssignableFrom(memberType))
            {
                Deserialize_MetaRef(ref context, reader, wireType, memberType, out value);
                return;
            }

            // Handle GameConfigDataContent<>
            if (memberType.IsGenericType && GameConfigDataType.IsAssignableTo(memberType.GetGenericTypeDefinition()))
            {
                var valueType = memberType.GenericTypeArguments[0];
                Deserialize_WireType(ref context, reader, wireType, valueType, out value);

                value = Activator.CreateInstance(memberType, value);
                return;
            }

            switch (wireType)
            {
                case WireDataType.Invalid:
                case WireDataType.EndStruct:
                case WireDataType.ObjectTable:
                    throw new InvalidOperationException($"Tried to read invalid type {wireType} at position {reader.Offset}.");

                case WireDataType.VarInt:
                    var baseType = memberType.IsEnum ? Enum.GetUnderlyingType(memberType) : memberType;

                    if (DynamicEnumInterface.IsAssignableFrom(baseType))
                    {
                        Deserialize_DynamicEnum(ref context, reader, out value);
                        value = baseType.BaseType.GetMethod(DynamicEnumFromId).Invoke(null, new[] { value });
                    }
                    else if (baseType == typeof(bool))
                        Deserialize_Boolean(ref context, reader, out value);
                    else if (baseType == typeof(uint))
                        Deserialize_UInt32(ref context, reader, out value);
                    else if (baseType == typeof(long))
                        Deserialize_Int64(ref context, reader, out value);
                    else if (baseType == typeof(ulong))
                        Deserialize_UInt64(ref context, reader, out value);
                    else
                        Deserialize_Int32(ref context, reader, out value);

                    if (memberType.IsEnum)
                        value = Enum.ToObject(memberType, value);

                    break;

                case WireDataType.VarInt128:
                    Deserialize_UInt128(ref context, reader, out value);
                    break;

                case WireDataType.NullableVarInt:
                    var resolvedType = memberType;

                    var nullableType = Nullable.GetUnderlyingType(resolvedType);
                    if (nullableType != null)
                        resolvedType = nullableType;

                    if (resolvedType == typeof(long))
                        Deserialize_Nullable_Int64(ref context, reader, out value);
                    else
                        Deserialize_Nullable_Int32(ref context, reader, out value);

                    if (memberType.GenericTypeArguments[0].IsEnum)
                        value = Enum.ToObject(memberType.GenericTypeArguments[0], value ?? 0);
                    break;

                case WireDataType.String:
                    Deserialize_String(ref context, reader, out value);

                    if (typeof(IStringId).IsAssignableFrom(memberType))
                        value = memberType.BaseType.GetMethod(StringIdFromString).Invoke(null, new[] { value });

                    break;

                case WireDataType.F64:
                    Deserialize_F64(ref context, reader, out value);
                    break;

                case WireDataType.F32:
                    Deserialize_F32(ref context, reader, out value);
                    break;

                case WireDataType.NullableF32:
                    if (IsNull(reader))
                        return;

                    Deserialize_F32(ref context, reader, out value);
                    break;

                case WireDataType.NullableF64:
                    if (IsNull(reader))
                        return;

                    Deserialize_F64(ref context, reader, out value);
                    break;

                case WireDataType.Float32:
                    Deserialize_Float32(ref context, reader, out value);
                    break;

                case WireDataType.Struct:
                    value = Activator.CreateInstance(memberType, true);
                    Deserialize_Members(ref context, reader, value, memberType);
                    return;

                // Classes and Nullable<T> where T : struct
                case WireDataType.NullableStruct:
                    if (IsNull(reader))
                        return;

                    if (memberType.IsGenericType && memberType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        memberType = memberType.GenericTypeArguments[0];

                    value = Activator.CreateInstance(memberType, true);
                    Deserialize_Members(ref context, reader, value, memberType);
                    return;

                case WireDataType.AbstractStruct:
                    var deriveId = reader.ReadVarInt();
                    if (deriveId == 0)
                        return;

                    var targetType = GetDerivableType(memberType, deriveId);

                    value = Activator.CreateInstance(targetType, true);
                    Deserialize_Members(ref context, reader, value, targetType);
                    return;

                case WireDataType.ValueCollection:
                    Deserialize_ValueCollection(ref context, reader, memberType, out value);
                    return;

                case WireDataType.KeyValueCollection:
                    Deserialize_KeyValueCollection(ref context, reader, memberType, out value);
                    return;

                case WireDataType.Bytes:
                    Deserialize_ByteArray(ref context, reader, out value);
                    return;

                default:
                    throw new InvalidOperationException($"Unknown wire type {wireType}.");
            }

            Tracer.Instance.Trace(value);
        }

        // CUSTOM: Deserialize null value
        private static bool IsNull(IOReader reader)
        {
            var hasValue = reader.ReadVarInt();
            return hasValue == 0;
        }

        // CUSTOM: Deserialize MetaRef<TItem>
        private static void Deserialize_MetaRef(ref MetaSerializationContext context, IOReader reader, WireDataType wireType, Type type, out object value)
        {
            var keyType = (Type)type.GetMethod(MetaRefGetKeyType).Invoke(null, Array.Empty<object>());

            Deserialize_WireType(ref context, reader, wireType, keyType, out var metaRefKey);

            var fromMethod = type.GetMethod(MetaRefFromKey);
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
            var elementType = collectionType.GetGenericArguments().FirstOrDefault() ?? collectionType.GetElementType();

            if (collectionType.IsArray)
            {
                var arrayValue = Array.CreateInstance(elementType!, collectionSize);

                for (var i = 0; i < collectionSize; i++)
                {
                    Tracer.Instance.Push($"[{i}]");

                    Deserialize_WireType(ref context, reader, listWireType, elementType, out var item);

                    Tracer.Instance.Pop();

                    arrayValue.SetValue(item, i);
                }

                outValue = arrayValue;
                return;
            }

            if (collectionType.IsAssignableTo(CollectionInterfaceType.MakeGenericType(elementType)))
            {
                var listValue = Activator.CreateInstance(collectionType.IsInterface ? CollectionType.MakeGenericType(elementType) : collectionType, collectionSize);
                var addMethod = listValue?.GetType().GetMethod(AddItemName);

                for (var i = 0; i < collectionSize; i++)
                {
                    Tracer.Instance.Push($"[{i}]");

                    Deserialize_WireType(ref context, reader, listWireType, elementType, out var item);

                    Tracer.Instance.Pop();

                    addMethod?.Invoke(listValue, new[] { item });
                }

                outValue = listValue;
            }
            else
            {
                var listValue = (IList)Activator.CreateInstance(ListType.MakeGenericType(elementType!), collectionSize);

                for (var i = 0; i < collectionSize; i++)
                {
                    Tracer.Instance.Push($"[{i}]");

                    Deserialize_WireType(ref context, reader, listWireType, elementType, out var item);

                    Tracer.Instance.Pop();

                    listValue?.Add(item);
                }

                outValue = listValue;
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

            var dictTypes = collectionType.GetGenericArguments().Take(2).ToArray();

            var keyWireType = TaggedWireSerializer.ReadWireType(reader);
            var valueWireType = TaggedWireSerializer.ReadWireType(reader);

            var dictValue = (IDictionary)Activator.CreateInstance(collectionType);
            for (var i = 0; i < dictCount; i++)
            {
                Tracer.Instance.Push($"[{i}]");
                Tracer.Instance.Push("Key");

                Deserialize_WireType(ref context, reader, keyWireType, dictTypes[0], out var key);

                Tracer.Instance.Pop();
                Tracer.Instance.Push($"[{key}]");

                Deserialize_WireType(ref context, reader, valueWireType, dictTypes[1], out var value);

                Tracer.Instance.Pop();
                Tracer.Instance.Pop();

                dictValue[key] = value;
            }

            outValue = dictValue;
        }

        private static void Deserialize_ByteArray(ref MetaSerializationContext context, IOReader reader, out object value)
        {
            value = reader.ReadByteString(context.MaxByteArraySize);
        }

        private static void Deserialize_Boolean(ref MetaSerializationContext context, IOReader reader, out object value)
        {
            value = reader.ReadByte() == 1;
        }

        private static void Deserialize_DynamicEnum(ref MetaSerializationContext context, IOReader reader, out object value)
        {
            value = reader.ReadVarInt();
        }

        private static void Deserialize_Int32(ref MetaSerializationContext context, IOReader reader, out object value)
        {
            value = reader.ReadVarInt();
        }

        private static void Deserialize_UInt32(ref MetaSerializationContext context, IOReader reader, out object value)
        {
            value = reader.ReadVarUInt();
        }

        private static void Deserialize_Int64(ref MetaSerializationContext context, IOReader reader, out object value)
        {
            value = reader.ReadVarLong();
        }

        private static void Deserialize_UInt64(ref MetaSerializationContext context, IOReader reader, out object value)
        {
            value = reader.ReadVarULong();
        }

        private static void Deserialize_UInt128(ref MetaSerializationContext context, IOReader reader, out object value)
        {
            value = reader.ReadVarUInt128();
        }

        private static void Deserialize_Nullable_Int32(ref MetaSerializationContext context, IOReader reader, out object value)
        {
            var flag = reader.ReadVarInt();
            value = flag == 0 ? null : reader.ReadVarInt();
        }

        private static void Deserialize_Nullable_Int64(ref MetaSerializationContext context, IOReader reader, out object value)
        {
            var flag = reader.ReadVarInt();
            value = flag == 0 ? null : reader.ReadVarLong();
        }

        private static void Deserialize_String(ref MetaSerializationContext context, IOReader reader, out object value)
        {
            value = reader.ReadString(context.MaxStringSize);
        }

        private static void Deserialize_F64(ref MetaSerializationContext context, IOReader reader, out object value)
        {
            value = reader.ReadF64();
        }

        private static void Deserialize_F32(ref MetaSerializationContext context, IOReader reader, out object value)
        {
            value = reader.ReadF32();
        }

        private static void Deserialize_Float32(ref MetaSerializationContext context, IOReader reader, out object value)
        {
            value = reader.ReadFloat();
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

        #region Tagged members

        private static void GetTaggedMembers(Type type, out IDictionary<int, FieldInfo> taggedFields, out IDictionary<int, PropertyInfo> taggedProperties)
        {
            var hasFields = _fields.TryGetValue(type, out taggedFields);
            var hasProperties = _properties.TryGetValue(type, out taggedProperties);

            if (hasFields && hasProperties)
                return;

            var implicitMembers = type.GetCustomAttribute<MetaImplicitMembersRangeAttribute>();
            var isImplicit = implicitMembers != null;

            var startIndex = implicitMembers?.StartIndex ?? 0;

            if (!hasFields)
                taggedFields = GetTaggedFields(type, isImplicit, ref startIndex);
            if (!hasProperties)
                taggedProperties = GetTaggedProperties(type, isImplicit, ref startIndex);
        }

        private static IDictionary<int, FieldInfo> GetTaggedFields(Type type, bool isImplicit, ref int startIndex)
        {
            if (_fields.TryGetValue(type, out var taggedFields))
                return taggedFields;

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

            if (type.BaseType != null)
            {
                var implicitMembers = type.BaseType.GetCustomAttribute<MetaImplicitMembersRangeAttribute>();
                isImplicit = implicitMembers != null;

                var startIndex1 = implicitMembers?.StartIndex ?? 0;

                var baseFields = GetTaggedFields(type.BaseType, isImplicit, ref startIndex1);
                foreach (var key in baseFields.Keys)
                    result[key] = baseFields[key];
            }

            return _fields[type] = result;
        }

        private static IDictionary<int, PropertyInfo> GetTaggedProperties(Type type, bool isImplicit, ref int startIndex)
        {
            if (_properties.TryGetValue(type, out var taggedProperties))
                return taggedProperties;

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

            if (type.BaseType != null)
            {
                var implicitMembers = type.BaseType.GetCustomAttribute<MetaImplicitMembersRangeAttribute>();
                isImplicit = implicitMembers != null;

                var startIndex1 = implicitMembers?.StartIndex ?? 0;

                var baseProperties = GetTaggedProperties(type.BaseType, isImplicit, ref startIndex1);
                foreach (var key in baseProperties.Keys)
                    result[key] = baseProperties[key];
            }

            return _properties[type] = result;
        }

        #endregion

        #region Derivable types

        private static Type GetDerivableType(Type baseType, int targetId)
        {
            return baseType == MetaMessageType ?
                GetMetaMessageType(baseType, targetId) :
                GetSerializableDerivedType(baseType, targetId);
        }

        private static Type GetSerializableDerivedType(Type baseType, int targetId)
        {
            // Get derived type from cache
            if (!_derivableTypes.TryGetValue(baseType, out var derivableTypes))
            {
                // Determine derivable types for base type
                var targetTypes = Assembly.GetExecutingAssembly().GetExportedTypes()
                    .Where(baseType.IsAssignableFrom)
                    .Select(x => (x, x.GetCustomAttribute<MetaSerializableDerivedAttribute>()))
                    .Where(x => x.Item2 != null);

                var distinctTypes = new Dictionary<int, Type>();
                foreach (var targetType in targetTypes)
                {
                    if (!distinctTypes.ContainsKey(targetType.Item2.TypeCode))
                        distinctTypes[targetType.Item2.TypeCode] = targetType.x;
                }

                _derivableTypes[baseType] = derivableTypes = distinctTypes;
            }

            if (!derivableTypes.TryGetValue(targetId, out var derivableType))
                throw new InvalidOperationException($"Unknown derivative {targetId} for type {baseType.FullName}");

            return derivableType;
        }

        private static Type GetMetaMessageType(Type baseType, int targetId)
        {
            // Get derived type from cache
            if (!_messageTypes.TryGetValue(baseType, out var derivableTypes))
            {
                // Determine derivable types for base type
                var targetTypes = Assembly.GetExecutingAssembly().GetExportedTypes()
                    .Where(baseType.IsAssignableFrom)
                    .Select(x => (x, x.GetCustomAttribute<MetaMessageAttribute>()))
                    .Where(x => x.Item2 != null);

                var distinctTypes = new Dictionary<int, Type>();
                foreach (var targetType in targetTypes)
                {
                    if (!distinctTypes.ContainsKey(targetType.Item2.TypeCode))
                        distinctTypes[targetType.Item2.TypeCode] = targetType.x;
                }

                _messageTypes[baseType] = derivableTypes = distinctTypes;
            }

            if (!derivableTypes.TryGetValue(targetId, out var derivableType))
                throw new InvalidOperationException($"Unknown derivative {targetId} for type {baseType.FullName}");

            return derivableType;
        }

        #endregion

        #region Tracer

        public class Tracer
        {
            private static readonly Lazy<Tracer> Lazy = new(() => new Tracer());
            public static Tracer Instance => Lazy.Value;

            private readonly Stack<string> _steps = new();
            private readonly HashSet<object> _registered = new();
            private readonly Dictionary<object, List<string>> _traced = new();

            public void Register(object value)
            {
                _registered.Add(value);
            }

            public void Push(string step)
            {
                _steps.Push(step);
            }

            public void Pop()
            {
                _steps.Pop();
            }

            public void Trace(object value)
            {
                if (value is IMetaRef metaRef)
                    value = metaRef.KeyObject;

                if (_registered.Contains(value))
                {
                    if (!_traced.TryGetValue(value, out var traces))
                        _traced[value] = traces = new();

                    traces.Add(string.Join('.', _steps.Reverse()));
                }
            }

            public IList<string> GetTraces(object value)
            {
                return _traced[value].ToArray();
            }
        }

        #endregion
    }
}
