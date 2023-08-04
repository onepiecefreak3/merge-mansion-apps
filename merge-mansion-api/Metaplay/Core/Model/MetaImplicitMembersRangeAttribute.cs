using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage((AttributeTargets)12)]
    public class MetaImplicitMembersRangeAttribute : Attribute
    {
        public int StartIndex;
        public int EndIndex;
        public MetaImplicitMembersRangeAttribute(int startIndex, int endIndex)
        {
        }
    }
}