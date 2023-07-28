using System;

namespace Metaplay.Core
{
	[AttributeUsage(AttributeTargets.Class)]
    public class EntityKindRegistryAttribute : Attribute
    {
        public readonly int StartIndex; // 0x10
        public readonly int EndIndex; // 0x14

        public EntityKindRegistryAttribute(int startIndex, int endIndex)
        {
            StartIndex = startIndex;
            EndIndex = endIndex;
        }
    }
}
