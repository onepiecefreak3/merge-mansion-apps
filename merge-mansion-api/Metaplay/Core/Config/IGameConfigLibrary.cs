using System.Collections.Generic;
using System;

namespace Metaplay.Core.Config
{
    public interface IGameConfigLibrary
    {
        // RVA: -1 Offset: -1 Slot: 2
        IEnumerable<KeyValuePair<object, object>> EnumerateAll();
        // RVA: -1 Offset: -1 Slot: 3
        object GetInfoByKey(object key);
    }

    public interface IGameConfigLibrary<TKey, TInfo> : IGameConfigLibrary
    {
        IEnumerable<TKey> Keys { get; }

        IEnumerable<TInfo> Values { get; }

        int Count { get; }
    }
}