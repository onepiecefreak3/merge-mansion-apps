using System;
using Metaplay.Metaplay.Core.IO;

namespace Metaplay.Metaplay.Core.Serialization
{
    public static class TaggedWireSerializer
    {
        public static int ReadTagId(IOReader reader)
        {
            return reader.ReadVarInt();
        }

        public static void WriteTagId(IOWriter writer, int tagId)
        {
            writer.WriteVarInt(tagId);
        }

        public static WireDataType ReadWireType(IOReader reader)
        {
            return (WireDataType)reader.ReadByte();
        }

        public static void WriteWireType(IOWriter writer, WireDataType wireType)
        {
            writer.WriteByte((byte)wireType);
        }

        public static void ExpectWireType(IOReader reader, Type type, WireDataType encounteredWireType, WireDataType expectedWireType)
        {
            if (encounteredWireType == expectedWireType)
                return;

            // TODO: Implement MetaWireDataTypeMismatchDeserializationException
            throw new InvalidOperationException($"Unexpected WireType {encounteredWireType} when reading value of type {type.Name} at offset {reader.Offset}, expected {expectedWireType}");
        }

        public static void SkipWireType(IOReader reader, WireDataType wireType)
        {
            switch (wireType)
            {
                case WireDataType.Null:
                    return;

                case WireDataType.VarInt:
                    reader.ReadVarLong();
                    break;

                case WireDataType.VarInt128:
                    reader.ReadVarUInt128();
                    break;

                case WireDataType.F32:
                    reader.ReadF32();
                    break;

                //case WireDataType.F32Vec2:
                //case WireDataType.F32Vec3:

                case WireDataType.F64:
                    reader.ReadF64();
                    break;

                //case WireDataType.F64Vec2:
                //case WireDataType.F64Vec3:

                case WireDataType.Float32:
                    reader.SkipBytes(4);
                    break;

                case WireDataType.Float64:
                    reader.SkipBytes(8);
                    break;

                case WireDataType.String:
                case WireDataType.Bytes:
                    var length = reader.ReadVarInt();
                    if (length < 1)
                        return;

                    reader.SkipBytes(length);
                    break;

                case WireDataType.AbstractStruct:
                    var isNullFlag2 = reader.ReadVarInt();
                    if (isNullFlag2 == 0)
                        return;

                    SkipStructMembers(reader);
                    break;

                case WireDataType.NullableStruct:
                    var isNullFlag1 = reader.ReadByte();
                    if (isNullFlag1 == 0)
                        return;

                    SkipStructMembers(reader);
                    break;

                case WireDataType.Struct:
                    SkipStructMembers(reader);
                    break;

                case WireDataType.ValueCollection:
                    var collectionSize = reader.ReadVarInt();
                    if (collectionSize < 0)
                        return;

                    var itemWireType = (WireDataType)reader.ReadByte();
                    for (var i = 0; i < collectionSize; i++)
                        SkipWireType(reader, itemWireType);

                    break;

                case WireDataType.KeyValueCollection:
                    var collectionSize1 = reader.ReadVarInt();
                    if (collectionSize1 < 0)
                        return;

                    var itemWireType1 = (WireDataType)reader.ReadByte();
                    var itemWireType2 = (WireDataType)reader.ReadByte();

                    for (var i = 0; i < collectionSize1; i++)
                    {
                        SkipWireType(reader, itemWireType1);
                        SkipWireType(reader, itemWireType2);
                    }

                    break;

                case WireDataType.NullableVarInt:
                case WireDataType.NullableVarInt128:
                case WireDataType.NullableF32:
                case WireDataType.NullableF32Vec2:
                case WireDataType.NullableF32Vec3:
                case WireDataType.NullableF64:
                case WireDataType.NullableF64Vec2:
                case WireDataType.NullableF64Vec3:
                case WireDataType.NullableFloat32:
                case WireDataType.NullableFloat64:
                case WireDataType.NullableMetaGuid:
                    var nullable = NullablePrimitiveWireTypeUnwrap(wireType);
                    var isNullFlag3 = reader.ReadVarInt();
                    if (isNullFlag3 == 0)
                        return;

                    SkipWireType(reader, nullable);
                    break;

                case WireDataType.MetaGuid:
                    reader.SkipBytes(16);
                    break;

                default:
                    throw new InvalidOperationException($"Unknown skip wire type {wireType}.");
            }
        }

        public static WireDataType NullablePrimitiveWireTypeUnwrap(WireDataType wireType)
        {
            if (wireType == WireDataType.NullableMetaGuid)
                return WireDataType.MetaGuid;

            return wireType - 19;
        }

        private static void SkipStructMembers(IOReader reader)
        {
            do
            {
                var memberWireType = (WireDataType)reader.ReadByte();
                if (memberWireType == WireDataType.EndStruct)
                    return;

                reader.ReadVarInt();
                SkipWireType(reader, memberWireType);
            } while (true);
        }
    }
}
