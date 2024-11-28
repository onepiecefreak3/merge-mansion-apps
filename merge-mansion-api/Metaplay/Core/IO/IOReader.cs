using System;
using System.Buffers.Binary;
using System.IO;
using System.Text;
using Metaplay.Core.Math;

namespace Metaplay.Core.IO
{
    public sealed class IOReader : IDisposable
    {
        // CUSTOM: Use Framework BinaryReader
        private BinaryReader _bReader;

        private static readonly UTF8Encoding s_encoding = new UTF8Encoding(false, true); // 0x0

        private LowLevelIOReader _reader; // 0x10
        private Decoder _decoder; // 0x30

        public int Offset => (int)_bReader.BaseStream.Position;//_reader._segmentOffset + _reader._previousSegmentsTotalSize;
        public int Remaining => (int)(_bReader.BaseStream.Length - _bReader.BaseStream.Position);//_reader.TotalLength - _reader._previousSegmentsTotalSize - _reader._segmentOffset;
        public bool IsFinished => _bReader.BaseStream.Position == _bReader.BaseStream.Length;//_reader.IsFinished;

        // Methods

        // RVA: 0x2365AB4 Offset: 0x2365AB4 VA: 0x2365AB4
        public IOReader(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            _reader = new LowLevelIOReader(null, bytes, 0, bytes.Length, 0, 0);

            // CUSTOM: Initialize BinaryReader
            _bReader = new BinaryReader(new MemoryStream(bytes), s_encoding);
        }

        // RVA: 0x235D5E0 Offset: 0x235D5E0 VA: 0x235D5E0
        public IOReader(byte[] bytes, int offset, int size)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            if (offset < 0 || bytes.Length < offset)
                throw new ArgumentOutOfRangeException(nameof(offset));

            if (size < 0 || offset + size > bytes.Length)
                throw new ArgumentOutOfRangeException(nameof(size));

            _reader = new LowLevelIOReader(null, bytes, offset, offset + size, 0, 0);

            // CUSTOM: Initialize BinaryReader
            _bReader = new BinaryReader(new MemoryStream(bytes, offset, size), s_encoding);
        }

        // RVA: 0x2365B58 Offset: 0x2365B58 VA: 0x2365B58
        public IOReader(IOBuffer buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));

            buffer.BeginRead();
            var seg = buffer.GetSegment(0);

            _reader = new LowLevelIOReader(buffer, seg.Buffer, 0, seg.Size, 0, 0);
        }

        // RVA: 0x2365CC0 Offset: 0x2365CC0 VA: 0x2365CC0 Slot: 4
        public void Dispose() { }

        // RVA: 0x2365D90 Offset: 0x2365D90 VA: 0x2365D90
        private Decoder GetDecoder()
        {
            throw new NotSupportedException();
        }

        // RVA: 0x2365E24 Offset: 0x2365E24 VA: 0x2365E24
        public void Seek(int targetOffset)
        {
            throw new NotSupportedException();
        }

        // RVA: 0x2365E78 Offset: 0x2365E78 VA: 0x2365E78
        public void SkipBytes(int numBytes)
        {
            _bReader.BaseStream.Position += numBytes;
        }

        // RVA: 0x2365FF0 Offset: 0x2365FF0 VA: 0x2365FF0
        public int ReadByte()
        {
            return _bReader.ReadByte();
        }

        // RVA: 0x236609C Offset: 0x236609C VA: 0x236609C
        public void ReadBytes(Span<byte> bytes)
        {
            _bReader.Read(bytes);
        }

        // RVA: 0x236614C Offset: 0x236614C VA: 0x236614C
        public void ReadBytes(byte[] bytes)
        {
            _bReader.Read(bytes);
        }

        // RVA: 0x236616C Offset: 0x236616C VA: 0x236616C
        public void ReadBytes(byte[] outBytes, int outOffset, int numBytes)
        {
            _bReader.Read(outBytes, outOffset, numBytes);
        }

        // RVA: 0x23661D8 Offset: 0x23661D8 VA: 0x23661D8
        public uint ReadVarUInt()
        {
            return (uint)_bReader.Read7BitEncodedInt();
            //var s = 0;
            //var t = 0;
            //var w = 0;
            //bool x;
            //do
            //{
            //    var v = ReadByte();
            //    if (((v >> 7) & 1) == 0)
            //        return (uint)(v << t | s);

            //    t += 7;
            //    s = (v & 0x7F) << t | s;
            //    x = w < 4;
            //    w++;
            //} while (x);

            //throw new IODecodingError($"Invalid varint found in IOBuffer (at offset {Offset})");
        }

        // RVA: 0x23662C4 Offset: 0x23662C4 VA: 0x23662C4
        public ulong ReadVarULong()
        {
            return (ulong)_bReader.Read7BitEncodedInt64();
        }

        public MetaUInt128 ReadVarUInt128()
        {
            var res = MetaUInt128.Zero;

            var shift = 0;
            do
            {
                var byteValue = _bReader.ReadByte();
                if (byteValue >> 7 == 0)
                {
                    var value1 = MetaUInt128.FromUInt(byteValue) << shift;
                    return res | value1;
                }

                var value = MetaUInt128.FromUInt((uint)(byteValue & 0x7F)) << shift;
                shift += 7;

                res |= value;

            } while (shift != 0x85);

            throw new InvalidOperationException($"Invalid VarUInt128 found in IOBuffer (at offset {Offset})");
        }
        
        public int ReadVarInt()
        {
            var v = ReadVarUInt();
            return (int)(-(v & 1) ^ v >> 1);
        }
        
        public long ReadVarLong()
        {
            var value = (long)ReadVarULong();
            return (value & 1) << 0x3F ^ value >> 1;
        }
        
        public F32 ReadF32()
        {
            return new F32(ReadInt32());
        }
        
        public F64 ReadF64()
        {
            return new F64(ReadInt64());
        }
        
        public int ReadInt32()
        {
            var buffer = _bReader.ReadBytes(4);
            return BinaryPrimitives.ReadInt32BigEndian(buffer);
        }

        // RVA: 0x2366588 Offset: 0x2366588 VA: 0x2366588
        public uint ReadUInt32()
        {
            throw new NotSupportedException();
        }
        
        public long ReadInt64()
        {
            var buffer = _bReader.ReadBytes(8);
            return BinaryPrimitives.ReadInt64BigEndian(buffer);
        }
        
        public ulong ReadUInt64()
        {
            var buffer = _bReader.ReadBytes(8);
            return BinaryPrimitives.ReadUInt64BigEndian(buffer);
        }
        
        public MetaUInt128 ReadUInt128()
        {
            return new MetaUInt128(ReadUInt64(), ReadUInt64());
        }
        
        public float ReadFloat()
        {
            var buffer = _bReader.ReadBytes(4);
            return BitConverter.ToSingle(buffer);
        }
        
        public double ReadDouble()
        {
            var buffer = _bReader.ReadBytes(8);
            return BitConverter.ToDouble(buffer);
        }

        // RVA: 0x2366A08 Offset: 0x2366A08 VA: 0x2366A08
        public string ReadString(int maxSize)
        {
            var varSize = ReadVarUInt();
            var size = -(varSize & 1) ^ varSize >> 1;   // HINT: Ceiled division by 2

            if (size == -1)
                return null;

            if (size < 0)
                throw new IODecodingError($"Invalid String size: {size}");

            if (size > maxSize)
                throw new IODecodingError($"String size too large: {size} (max={maxSize})");

            var buffer = _bReader.ReadBytes((int)size);
            return s_encoding.GetString(buffer);
        }

        public byte[] ReadByteString(int maxLength)
        {
            var size = ReadVarInt();
            if (size < 0)
                return null;

            if (_bReader.BaseStream.Length - _bReader.BaseStream.Position < size)
                throw new InvalidOperationException($"Byte array larger than remaining input: length={size}, remaining={_bReader.BaseStream.Length - _bReader.BaseStream.Position})");

            if (size <= maxLength)
                return _bReader.ReadBytes(size);

            throw new InvalidOperationException($"Deserialized byte array too large: {size} (max={maxLength})");
        }
    }
}
