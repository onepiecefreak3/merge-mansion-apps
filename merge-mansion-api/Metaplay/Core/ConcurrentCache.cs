using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Metaplay.Core
{
    public class ConcurrentCache<TKey, TValue>
    {
        private ConcurrentDictionary<TKey, Task<TValue>> _cache; // 0x0

        public ConcurrentCache()
        {
            _cache = new ConcurrentDictionary<TKey, Task<TValue>>();
        }

        public Task<TValue> GetAsync(TKey key, Func<TKey, Task<TValue>> valueFactory)
        {
            if (_cache.TryGetValue(key, out var value)) 
                return value;

            if (valueFactory == null)
                throw new InvalidOperationException("valueFactory is not given, but necessary.");

            return _cache[key] = valueFactory(key);
        }
    }
}
