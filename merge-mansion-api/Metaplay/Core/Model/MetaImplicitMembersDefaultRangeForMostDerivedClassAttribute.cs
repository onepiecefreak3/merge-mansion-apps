using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage((AttributeTargets)1036)]
    public class MetaImplicitMembersDefaultRangeForMostDerivedClassAttribute : Attribute
    {
        public int StartIndex;
        public int EndIndex;
        public MetaImplicitMembersDefaultRangeForMostDerivedClassAttribute(int startIndex, int endIndex)
        {
        }
    }
}