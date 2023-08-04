using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage((AttributeTargets)4, AllowMultiple = true)]
    public class MetaReservedMembersAttribute : Attribute
    {
        public int StartIndex;
        public int EndIndex;
        public MetaReservedMembersAttribute(int startNdx, int endNdx)
        {
        }
    }
}