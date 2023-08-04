using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage((AttributeTargets)1052)]
    public class MetaAllowNoSerializedMembers : Attribute
    {
        public MetaAllowNoSerializedMembers()
        {
        }
    }
}