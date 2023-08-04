using System;

namespace Metaplay.Core
{
    public class PrettyPrintAttribute : Attribute
    {
        public PrettyPrintFlag Flags { get; set; }

        public PrettyPrintAttribute(PrettyPrintFlag flags)
        {
        }
    }
}