using System.Collections.Generic;
using System;

namespace Metaplay.Core.Config
{
    public interface IGameConfigLibrary : IGameConfigEntry
    {
        // RVA: -1 Offset: -1 Slot: 0
        Type ItemType { get; }
        // RVA: -1 Offset: -1 Slot: 1
        int Count { get; }
        // RVA: -1 Offset: -1 Slot: 2
        IEnumerable<KeyValuePair<object, object>> EnumerateAll();
        // RVA: -1 Offset: -1 Slot: 3
        object GetInfoByKey(object key);
    }

    public interface IGameConfigLibrary<TKey, TInfo> : IGameConfigLibrary, IGameConfigEntry
    {
        IEnumerable<TKey> Keys { get; }

        IEnumerable<TInfo> Values { get; }
    }
}