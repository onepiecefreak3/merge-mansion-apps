using System;
using System.Collections.Generic;

namespace Metaplay.Core.Config
{
    public interface IGameConfigLibraryEntry : IGameConfigLibrary, IGameConfigEntry
    {
        Type ItemType { get; }

        IEnumerable<Type> ItemTypeHierarchy { get; }

        int Count { get; }
    }
}