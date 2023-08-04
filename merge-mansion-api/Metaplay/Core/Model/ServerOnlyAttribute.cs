using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage((AttributeTargets)384)]
    public class ServerOnlyAttribute : MetaMemberFlagAttribute
    {
        public override MetaMemberFlags Flags { get; }

        public ServerOnlyAttribute()
        {
        }
    }
}