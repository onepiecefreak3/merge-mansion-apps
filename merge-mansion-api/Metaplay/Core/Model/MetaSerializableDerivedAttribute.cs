using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MetaSerializableDerivedAttribute : Attribute
    {
        // 0x10
        public readonly int DeriveId;

        public MetaSerializableDerivedAttribute(int deriveDeriveId)
        {
            DeriveId = deriveDeriveId;
        }
    }
}
