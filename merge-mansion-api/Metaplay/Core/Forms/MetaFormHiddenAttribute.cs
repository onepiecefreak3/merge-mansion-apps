using System;

namespace Metaplay.Core.Forms
{
    [AttributeUsage((AttributeTargets)4)]
    public class MetaFormHiddenAttribute : Attribute
    {
        public MetaFormHiddenAttribute()
        {
        }
    }
}