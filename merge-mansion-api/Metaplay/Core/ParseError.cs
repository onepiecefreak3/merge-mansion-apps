using System;

namespace Metaplay.Core
{
    public class ParseError : Exception
    {
        // RVA: 0x1D55D60 Offset: 0x1D55D60 VA: 0x1D55D60
        public ParseError() { }

        // RVA: 0x1D55DB8 Offset: 0x1D55DB8 VA: 0x1D55DB8
        public ParseError(string message) : base(message) { }

        // RVA: 0x1D55E20 Offset: 0x1D55E20 VA: 0x1D55E20
        public ParseError(string message, Exception inner) : base(message, inner) { }
    }
}
