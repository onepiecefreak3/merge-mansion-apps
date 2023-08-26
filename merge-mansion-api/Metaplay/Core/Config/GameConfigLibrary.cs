using System;
using System.Collections.Generic;
using System.Linq;
using Metaplay.Core.Serialization;
using Metaplay.Generated;
using System.Reflection;

namespace Metaplay.Core.Config
{
    [DefaultMember("Item")]
    public class GameConfigLibrary<TKey, TInfo> : IGameConfigLibrary<TKey, TInfo>, IGameConfigLibrary, IGameConfigEntry
    {
        private Dictionary<TKey, TInfo> _infos; // 0x10
        private Dictionary<TKey, TInfo> _aliases; // 0x18
        protected GameConfigLibrary(Dictionary<TKey, TInfo> infos, IGameConfigDataRegistry registry)
        {
            _infos = infos;
            RegisterReferenceResolversTo(registry);
        }

        public void ResolveMetaRefs(IGameConfigDataResolver resolver)
        {
            MetaSerialization.ResolveMetaRefsInTable(_infos.Values.ToList(), resolver);
        }

        public void PostLoad()
        {
            throw new NotImplementedException();
        }

        public void BuildTimeValidate()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<object, object>> EnumerateAll()
        {
            return _infos.Select(x => new KeyValuePair<object, object>(x.Key, x.Value));
        }

        public object GetInfoByKey(object key)
        {
            if (_infos.ContainsKey((TKey)key))
                return _infos[(TKey)key];
            return null;
        }

        public bool TryGetValue(TKey key, out TInfo info)
        {
            info = default;
            if (!_infos.ContainsKey(key))
                return false;
            info = _infos[key];
            return true;
        }

        public TInfo GetValueOrDefault(TKey key)
        {
            TryGetValue(key, out var info);
            return info;
        }

        internal static GameConfigLibrary<TKey, TInfo> FromItems(Dictionary<TKey, TInfo> items, IGameConfigDataRegistry registry)
        {
            return new GameConfigLibrary<TKey, TInfo>(items, registry);
        }

        internal void RegisterReferenceResolversTo(IGameConfigDataRegistry registry)
        {
            registry.RegisterReferenceResolver(typeof(TInfo), GetInfoByKey);
            if (typeof(TInfo).BaseType != null)
                registry.RegisterReferenceResolver(typeof(TInfo).BaseType, GetInfoByKey);
        }

        public int Count => _infos.Count;
        public Dictionary<TKey, TInfo>.KeyCollection Keys => _infos.Keys;
        public Dictionary<TKey, TInfo>.ValueCollection Values => _infos.Values;
        public IReadOnlyDictionary<TKey, TInfo> Infos => _infos;

        IEnumerable<TKey> Metaplay.Core.Config.IGameConfigLibrary<TKey, TInfo>.Keys => Keys;

        IEnumerable<TInfo> Metaplay.Core.Config.IGameConfigLibrary<TKey, TInfo>.Values => Values;
        public TInfo Item => Values.FirstOrDefault();

        GameConfigLibrary()
        {
        }
    }
}