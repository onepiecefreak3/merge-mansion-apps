using System;

namespace Metaplay.Core.Forms
{
    [AttributeUsage((AttributeTargets)4, Inherited = true)]
    public class MetaFormUseAsContextAttribute : Attribute
    {
        public MetaFormUseAsContextAttribute()
        {
        }
    }
}