using System;

namespace Metaplay.Core.Model
{
    public abstract class MetaMemberFlagAttribute : Attribute
    {
        public abstract MetaMemberFlags Flags { get; }

        protected MetaMemberFlagAttribute()
        {
        }
    }
}