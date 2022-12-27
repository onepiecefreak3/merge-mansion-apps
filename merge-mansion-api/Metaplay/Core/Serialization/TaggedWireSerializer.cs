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

                case WireDataType.VarInt128:
                    reader.ReadVarUInt128();
                    break;

                case WireDataType.VarInt:
                    reader.ReadVarLong();
                    break;

                case WireDataType.Struct:
                    SkipStructMembers(reader);
                    break;

                case WireDataType.String:
                case WireDataType.Bytes:
                    var length = reader.ReadVarInt();
                    if (length < 1)
                        return;

                    reader.SkipBytes(length);
                    break;

                case WireDataType.F64:
                    reader.ReadF64();
                    break;

                case WireDataType.NullableF64:
                    var nullable = NullablePrimitiveWireTypeUnwrap(wireType);
                    var v = reader.ReadVarInt();
                    if (v == 0)
                        return;

                    SkipWireType(reader, nullable);
                    break;

                case WireDataType.ValueCollection:
                    var collectionSize = reader.ReadVarInt();
                    if (collectionSize < 0)
                        return;

                    var itemWireType = (WireDataType)reader.ReadByte();
                    for (var i = 0; i < collectionSize; i++)
                        SkipWireType(reader, itemWireType);

                    break;

                case WireDataType.NullableStruct:
                    var isNullFlag1 = reader.ReadByte();
                    if (isNullFlag1 == 0)
                        return;

                    SkipStructMembers(reader);
                    break;

                case WireDataType.AbstractStruct:
                    var isNullFlag2 = reader.ReadVarInt();
                    if (isNullFlag2 == 0)
                        return;

                    SkipStructMembers(reader);
                    break;

                default:
                    break;
            }
        }

        public static WireDataType NullablePrimitiveWireTypeUnwrap(WireDataType wireType)
        {
            var types = new[]
            {
                WireDataType.VarInt, WireDataType.VarInt128, WireDataType.F32, WireDataType.F32Vec2,
                WireDataType.F32Vec3, WireDataType.F64, WireDataType.F64Vec2, WireDataType.F64Vec3,
                WireDataType.Float32, WireDataType.Float64, WireDataType.VarInt, WireDataType.MetaGuid
            };

            var wt = (int)wireType - 0x15;
            if (wt < 0xC && (0xBFF >> (wt & 0x1F) & 1) != 0)
                return types[wt];

            throw new ArgumentException(nameof(wireType));
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
