using System.Collections.Generic;
using System;

namespace Metaplay.Core.Config
{
    public interface IGameConfigLibrary : IGameConfigEntry
    {
        // Methods
        // RVA: -1 Offset: -1 Slot: 0
        IEnumerable<KeyValuePair<object, object>> EnumerateAll();
        // RVA: -1 Offset: -1 Slot: 1
        object GetInfoByKey(object key);
        int Count { get; }
    }

    public interface IGameConfigLibrary<TKey, TInfo> : IGameConfigLibrary, IGameConfigEntry
    {
        IEnumerable<TKey> Keys { get; }

        IEnumerable<TInfo> Values { get; }
    }
}