using System;
using System.IO;
using System.Reflection.Metadata;

namespace Metaplay.Metaplay.Core
{
    public class LimitedReadStream : Stream
    {
        // 0x28
        private Stream _underlying;
        // 0x30
        private int _limit;
        // 0x34
        private int _numReadSoFar;

        public override long Position
        {
            get => throw new NotSupportedException(nameof(Position));
            set => throw new NotSupportedException(nameof(Position));
        }
        public override long Length => throw new NotSupportedException(nameof(Length));
        public override bool CanWrite => false;
        public override bool CanSeek => false;
        public override bool CanRead => _underlying.CanRead;

        public LimitedReadStream(Stream underlying, int limit)
        {
            _underlying = underlying ?? throw new ArgumentNullException(nameof(underlying));

            if (limit < 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit cannot be negative");

            _limit = limit;
        }

        public override void Flush() { }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var read = _underlying.Read(buffer, offset, count);
            if (read < 0)
                throw new InvalidOperationException($"Read from underlying stream (type {_underlying.GetType()}) returned a negative value {read} (requested {count})");

            if (read <= count)
            {
                var remaining = _limit - _numReadSoFar;
                if (read <= remaining)
                {
                    _numReadSoFar += read;
                    return read;
                }

                throw new LimitExceededException($"Reading from underlying stream (type {_underlying.GetType()}) gave {read} bytes, but we have only {remaining} remaining until limit (read {_numReadSoFar} so far out of the limit of {_limit})");
            }

            throw new InvalidOperationException($"Read from underlying stream (type {_underlying.GetType()}) returned {read}, more than the requested {count}");
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public class LimitExceededException : Exception
        {
            public LimitExceededException(string message) : base(message) { }
        }
    }
}
