using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage((AttributeTargets)384)]
    public class TransientAttribute : MetaMemberFlagAttribute
    {
        public override MetaMemberFlags Flags { get; }

        public TransientAttribute()
        {
        }
    }
}