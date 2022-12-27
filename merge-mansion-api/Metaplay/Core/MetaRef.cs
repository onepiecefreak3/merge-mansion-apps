using System;
using System.Linq;
using System.Reflection;
using Metaplay.Metaplay.Core.Config;

namespace Metaplay.Metaplay.Core
{
    public class MetaRef<TItem> : IMetaRef where TItem : class, IGameConfigData
    {
        private static readonly Type KeyType = typeof(TItem).GetInterfaces().FirstOrDefault(x => typeof(IGameConfigData).IsAssignableFrom(x))?.GetGenericArguments().FirstOrDefault(); // 0x0
        private static readonly PropertyInfo KeyProperty = typeof(TItem).GetProperty("ConfigKey"); // 0x8

        private readonly object _key; // 0x10
        private readonly TItem _item; // 0x18

        public object KeyObject => _key;
        public TItem Ref => _item ?? throw new InvalidOperationException($"Tried to get reference to '{_key}' from MetaRef<{typeof(TItem)}> but the reference hasn't yet been resolved");
        public bool IsResolved => _item != null;

        private MetaRef(object key, TItem item)
        {
            _key = key;
            _item = item;
        }

        public static MetaRef<TItem> FromKey(object key)
        {
            var key1 = key;

            if (KeyType.IsEnum)
                key1 = Enum.ToObject(KeyType, key);
            if (typeof(IStringId).IsAssignableFrom(KeyType))
                key1 = KeyType.BaseType.GetMethod("FromString").Invoke(null, new[] { key });

            return new MetaRef<TItem>(key1, null);
        }

        public MetaRef<TItem> CreateResolved(IGameConfigDataResolver resolver)
        {
            if (_key is IStringId sid)
                if (sid.Value == null)
                    return this;

            return new MetaRef<TItem>(_key, (TItem)resolver.ResolveReference(typeof(TItem), _key));
        }
    }
}
