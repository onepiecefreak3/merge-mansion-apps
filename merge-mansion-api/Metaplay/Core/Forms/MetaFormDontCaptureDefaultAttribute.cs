using System;

namespace Metaplay.Core.Forms
{
    [AttributeUsage((AttributeTargets)384)]
    public class MetaFormDontCaptureDefaultAttribute : Attribute
    {
        public MetaFormDontCaptureDefaultAttribute()
        {
        }
    }
}