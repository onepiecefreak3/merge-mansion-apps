using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage((AttributeTargets)384)]
    public class MaxCollectionSizeAttribute : Attribute
    {
        public int Size;
        public MaxCollectionSizeAttribute(int size)
        {
        }
    }
}