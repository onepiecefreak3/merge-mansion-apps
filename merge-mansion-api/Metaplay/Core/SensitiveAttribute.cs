using System;

namespace Metaplay.Core
{
    [AttributeUsage((AttributeTargets)384)]
    public class SensitiveAttribute : Attribute
    {
        public SensitiveAttribute()
        {
        }
    }
}