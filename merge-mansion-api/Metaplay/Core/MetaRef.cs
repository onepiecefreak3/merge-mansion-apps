using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Metaplay.Core.Config;

namespace Metaplay.Core
{
    public class MetaRef<TItem> : IMetaRef where TItem : class, IGameConfigData
    {
        private static readonly Type KeyType = typeof(TItem).GetInterfaces().FirstOrDefault(x => typeof(IGameConfigData).IsAssignableFrom(x))?.GetGenericArguments().FirstOrDefault(); // 0x0
        private static readonly PropertyInfo KeyProperty = typeof(TItem).GetProperty("ConfigKey"); // 0x8
        private readonly object _key; // 0x10
        private readonly TItem _item; // 0x18
        public Type ItemType => typeof(TItem);
        public object KeyObject => _key;
        public bool IsResolved => _item != null;
        public TItem Ref => _item ?? throw new InvalidOperationException($"Tried to get reference to '{_key}' from MetaRef<{typeof(TItem)}> but the reference hasn't yet been resolved");

        private MetaRef(object key, TItem item)
        {
            _key = key;
            _item = item;
        }

        public static Type GetKeyType() => KeyType;
        public static MetaRef<TItem> FromKey(object key)
        {
            return new MetaRef<TItem>(key, null);
        }

        public IMetaRef CreateResolved(IGameConfigDataResolver resolver)
        {
            if (_key is IStringId { Value: null })
                return this;
            return new MetaRef<TItem>(_key, (TItem)resolver.ResolveReference(typeof(TItem), _key));
        }

        public TItem MaybeRef => _item;

        object IMetaRef.MaybeRefObject => MaybeRef;
    }
}