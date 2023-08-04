using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage((AttributeTargets)384)]
    public class ExcludeFromGdprExportAttribute : MetaMemberFlagAttribute
    {
        public override MetaMemberFlags Flags { get; }

        public ExcludeFromGdprExportAttribute()
        {
        }
    }
}