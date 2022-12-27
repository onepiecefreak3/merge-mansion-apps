using System;

namespace Metaplay.Metaplay.Core.IO
{
    public struct IOBufferSegment
    {
        // 0x0
        public byte[] Buffer;
        // 0x8
        public int Size;

        public static IOBufferSegment Empty => new IOBufferSegment { Buffer = Array.Empty<byte>(), Size = 0 };
    }
}
