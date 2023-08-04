using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage((AttributeTargets)12, AllowMultiple = true)]
    public class MetaBlockedMembersAttribute : Attribute
    {
        public int[] BlockedMemberIds;
        public MetaBlockedMembersAttribute(int[] blockedMemberIds)
        {
        }
    }
}