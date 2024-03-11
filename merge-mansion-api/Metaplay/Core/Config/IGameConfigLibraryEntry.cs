using System;
using System.Collections.Generic;

namespace Metaplay.Core.Config
{
    public interface IGameConfigLibraryEntry : IGameConfigLibrary, IGameConfigEntry
    {
        Type ItemType { get; }

        int Count { get; }
    }
}