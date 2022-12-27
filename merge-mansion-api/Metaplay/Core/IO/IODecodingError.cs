using System;

namespace Metaplay.Metaplay.Core.IO
{
    public class IODecodingError : Exception
    {
        public IODecodingError() { }

        // RVA: 0x23658A8 Offset: 0x23658A8 VA: 0x23658A8
        public IODecodingError(string message) : base(message) { }

        // RVA: 0x2365910 Offset: 0x2365910 VA: 0x2365910
        public IODecodingError(string message, Exception inner) : base(message, inner) { }
    }
}
