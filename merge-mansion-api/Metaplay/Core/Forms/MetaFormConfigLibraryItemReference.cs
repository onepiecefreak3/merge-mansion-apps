using System;

namespace Metaplay.Core.Forms
{
    [AttributeUsage((AttributeTargets)4)]
    public class MetaFormConfigLibraryItemReference : Attribute
    {
        public Type ConfigItemType { get; }

        public MetaFormConfigLibraryItemReference(Type configItemType)
        {
        }
    }
}