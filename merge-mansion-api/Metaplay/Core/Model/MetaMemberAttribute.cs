using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MetaMemberAttribute : Attribute
    {
        // 0x10
        public readonly int TagId;
        // 0x14
        public readonly MetaMemberFlags Flags;

        public MetaMemberAttribute(int tagId, MetaMemberFlags flags = 0)
        {
            if (tagId <= 0)
                throw new ArgumentException($"MetaMemberAttribute's tagId must be positive (is {tagId})");

            TagId = tagId;
            Flags = flags;
        }
    }
}
