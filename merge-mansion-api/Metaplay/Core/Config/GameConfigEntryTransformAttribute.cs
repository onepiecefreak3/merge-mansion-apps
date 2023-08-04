using System;

namespace Metaplay.Core.Config
{
    [AttributeUsage((AttributeTargets)128)]
    public class GameConfigEntryTransformAttribute : Attribute
    {
        public Type SourceItemType;
        public GameConfigEntryTransformAttribute(Type sourceItemType)
        {
        }
    }
}