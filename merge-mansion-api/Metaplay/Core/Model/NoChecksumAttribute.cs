using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage((AttributeTargets)384)]
    public class NoChecksumAttribute : MetaMemberFlagAttribute
    {
        public override MetaMemberFlags Flags { get; }

        public NoChecksumAttribute()
        {
        }
    }
}