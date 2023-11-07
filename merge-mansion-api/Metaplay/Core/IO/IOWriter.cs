using System;
using System.Buffers.Binary;
using System.IO;
using System.Text;
using Metaplay.Core.Math;
using UInt128 = Metaplay.Core.Math.UInt128;

namespace Metaplay.Core.IO
{
    public sealed class IOWriter : IDisposable
    {
        // CUSTOM: Use Framework BinaryWriter
        private BinaryWriter _bWriter; // 0x10

        public int Offset => (int)_bWriter.BaseStream.Position;

        public IOWriter()
        {
            // CUSTOM: Initialize BinaryReader
            _bWriter = new BinaryWriter(new MemoryStream());
        }

        public void Dispose()
        {
            _bWriter.Dispose();
        }

        public void WriteByte(byte value)
        {
            _bWriter.Write(value);
        }

        // RVA: 0x236609C Offset: 0x236609C VA: 0x236609C
        public void WriteSpan(ReadOnlySpan<byte> bytes)
        {
            _bWriter.Write(bytes);
        }

        // RVA: 0x236614C Offset: 0x236614C VA: 0x236614C
        public void WriteBytes(byte[] bytes, int offset, int numBytes)
        {
            _bWriter.Write(bytes, offset, numBytes);
        }

        public void WriteVarUInt(uint value)
        {
            _bWriter.Write7BitEncodedInt((int)value);
        }

        public void WriteVarULong(ulong value)
        {
            _bWriter.Write7BitEncodedInt64((long)value);
        }

        public void WriteVarUInt128(UInt128 value)
        {
            var compare = UInt128.FromUInt(0x80);

            do
            {
                if (value.CompareTo(compare) < 0)
                {
                    _bWriter.Write((byte)(value.Low & 0x7F));
                    return;
                }

                _bWriter.Write((byte)(value.Low | 0xFFFFFF80));

                value.Low = value.Low >> 7 | value.High << 0x39;
                value.High >>= 7;
            } while ((value.Low | value.High) != 0);
        }

        public void WriteVarInt(int value)
        {
            WriteVarUInt((uint)((value >> 0x1F) ^ value << 1));
        }

        public void WriteVarLong(long value)
        {
            WriteVarULong((ulong)(value >> 0x3F ^ value << 1));
        }

        public void WriteF32(F32 value)
        {
            WriteInt32(value.Raw);
        }

        public void WriteF64(F64 value)
        {
            WriteInt64(value.Raw);
        }

        public void WriteInt32(int value)
        {
            var buffer = new byte[4];
            BinaryPrimitives.WriteInt32BigEndian(buffer, value);

            _bWriter.Write(buffer);
        }

        public void WriteUInt32(uint value)
        {
            var buffer = new byte[4];
            BinaryPrimitives.WriteUInt32BigEndian(buffer, value);

            _bWriter.Write(buffer);
        }

        public void WriteInt64(long value)
        {
            var buffer = new byte[8];
            BinaryPrimitives.WriteInt64BigEndian(buffer, value);

            _bWriter.Write(buffer);
        }

        public void WriteUInt64(ulong value)
        {
            var buffer = new byte[8];
            BinaryPrimitives.WriteUInt64BigEndian(buffer, value);

            _bWriter.Write(buffer);
        }

        public void WriteUInt128(UInt128 value)
        {
            WriteUInt64(value.High);
            WriteUInt64(value.Low);
        }

        public void WriteFloat(float value)
        {
            throw new NotSupportedException();
        }

        public void WriteDouble(double value)
        {
            throw new NotSupportedException();
        }

        public void WriteString(string value)
        {
            var length = -1;
            if (value != null)
                length = value.Length;

            var size = (uint)((length >> 0x1F) ^ length << 1);
            WriteVarUInt(size);

            if (value != null)
                _bWriter.Write(Encoding.UTF8.GetBytes(value));
        }

        public void WriteByteString(byte[] value)
        {
            throw new NotSupportedException();
        }

        // CUSTOM: Return framework stream
        public MemoryStream ConvertToStream()
        {
            return (MemoryStream)_bWriter.BaseStream;
        }
    }
}
