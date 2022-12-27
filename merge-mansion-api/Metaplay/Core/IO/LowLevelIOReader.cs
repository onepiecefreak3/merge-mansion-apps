using System;

namespace Metaplay.Metaplay.Core.IO
{
    internal struct LowLevelIOReader
    {
        // Fields
        private IOBuffer _buffer; // 0x0
        internal byte[] _segmentData; // 0x8
        internal int _segmentOffset; // 0x10
        internal int _segmentEndOffset; // 0x14
        private int _segmentIndex; // 0x18
        internal int _previousSegmentsTotalSize; // 0x1C

        public int TotalOffset => _segmentOffset + _previousSegmentsTotalSize;
        public int TotalLength => _buffer?.Count ?? _segmentEndOffset;
        public int Remaining => TotalLength - _previousSegmentsTotalSize - _segmentOffset;
        public bool IsFinished => _segmentOffset == _segmentEndOffset && (_buffer == null || _segmentIndex == _buffer.NumSegments - 1);
        public bool IsDisposed => _segmentData == null;

        internal LowLevelIOReader(IOBuffer buffer, byte[] segmentData, int segmentOffset, int segmentEndOffset, int segmentIndex, int previousSegmentsTotalSize)
        {
            _buffer = buffer;
            _segmentData = segmentData;
            _segmentOffset = segmentOffset;
            _segmentEndOffset = segmentEndOffset;
            _segmentIndex = segmentIndex;
            _previousSegmentsTotalSize = previousSegmentsTotalSize;
        }

        public void Dispose()
        {
            if (_segmentData == null)
                return;

            _buffer?.EndRead();

            _buffer = null;
            _segmentData = null;
            _segmentOffset = 0;
            _segmentEndOffset = 0;
            _segmentIndex = 0;
            _previousSegmentsTotalSize = 0;
        }

        // RVA: 0x2366E18 Offset: 0x2366E18 VA: 0x2366E18
        internal bool NextSegment()
        {
            if (_buffer == null)
                return false;

            if (_segmentIndex == _buffer.NumSegments - 1)
                return false;

            _segmentIndex++;
            _previousSegmentsTotalSize += _segmentOffset;

            var segment = _buffer.GetSegment(_segmentIndex);
            _segmentData = segment.Buffer;
            _segmentOffset = 0;
            _segmentEndOffset = segment.Size;

            return true;
        }

        // RVA: 0x2368754 Offset: 0x2368754 VA: 0x2368754
        private void SeekToStart()
        {
            if (_buffer != null)
            {
                var firstSegment = _buffer.GetSegment(0);

                _segmentData = firstSegment.Buffer;
                _segmentEndOffset = firstSegment.Size;
                _segmentIndex = 0;
            }

            _segmentOffset = 0;
        }

        // RVA: 0x2365E50 Offset: 0x2365E50 VA: 0x2365E50
        public void Seek(int targetOffset)
        {
            SeekToStart();
            SkipBytes(targetOffset);
        }

        // RVA: 0x2368810 Offset: 0x2368810 VA: 0x2368810
        private void CheckIsDisposed()
        {
            if (_segmentData != null)
                return;

            throw new ObjectDisposedException(nameof(IOReader));
        }

        // RVA: 0x2365E80 Offset: 0x2365E80 VA: 0x2365E80
        public void SkipBytes(int numBytes)
        {
            CheckIsDisposed();

            if (numBytes < 0)
                throw new ArgumentException($"Invalid numBytes value {numBytes}");

            if (numBytes == 0)
                return;

            do
            {
                while (_segmentEndOffset - _segmentOffset == 0)
                    if (!NextSegment())
                        throw new IODecodingError("SkipBytes(): going past end-of-buffer");

                var minCount = System.Math.Min(numBytes, _segmentEndOffset - _segmentOffset);

                numBytes -= minCount;
                _segmentOffset += minCount;
            } while (numBytes > 0);
        }

        // RVA: 0x2365FF8 Offset: 0x2365FF8 VA: 0x2365FF8
        public int ReadByte()
        {
            CheckIsDisposed();

            while (_segmentOffset == _segmentEndOffset)
            {
                if (!NextSegment())
                    throw new IODecodingError("ReadByte(): reading past end-of-buffer");
            }

            if (_segmentOffset >= _segmentData.Length)
                throw new IndexOutOfRangeException();

            return _segmentData[_segmentOffset++];
        }
    }
}
