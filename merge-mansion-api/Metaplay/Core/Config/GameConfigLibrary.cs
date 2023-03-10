using System;
using System.Collections.Generic;
using System.Linq;
using Metaplay.Metaplay.Generated;

namespace Metaplay.Metaplay.Core.Config
{
    public class GameConfigLibrary<TKey, TInfo> : IGameConfigLibrary
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
            TypeSerializer.ResolveMetaRefs_List(_infos.Values.ToList(), resolver);
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
    }
}
