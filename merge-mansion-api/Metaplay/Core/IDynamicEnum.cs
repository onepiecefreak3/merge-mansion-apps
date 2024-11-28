using System;

namespace Metaplay.Core
{
    public interface IDynamicEnum
    {
        int Id { get; }

        string Name { get; }
    }
}