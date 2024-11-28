using System;
using System.Collections.Generic;
using System.Linq;
using Metaplay.Core.Serialization;
using Metaplay.Generated;
using System.Reflection;
using Metaplay.Core.Player;

namespace Metaplay.Core.Config
{
    [DefaultMember("Item")]
    public class GameConfigLibrary<TKey, TInfo> : IGameConfigLibraryEntry, IGameConfigLibrary, IGameConfigEntry, IGameConfigMember, IGameConfigLibrary<TKey, TInfo>
    {
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
            if (key != null && _infos.ContainsKey((TKey)key))
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

        public Type ItemType => typeof(TInfo);
        public int Count => _infos.Count;
        public IEnumerable<TKey> Keys => _infos.Keys;
        public IEnumerable<TInfo> Values => _infos.Values;

        IEnumerable<TKey> Metaplay.Core.Config.IGameConfigLibrary<TKey, TInfo>.Keys => Keys;

        IEnumerable<TInfo> Metaplay.Core.Config.IGameConfigLibrary<TKey, TInfo>.Values => Values;
        public TInfo Item => Values.FirstOrDefault();

        GameConfigLibrary()
        {
        }

        private GameConfigRuntimeStorageMode _storageMode;
        private GameConfigLibraryDeduplicationStorage<TKey, TInfo> _deduplicationStorage;
        private GameConfigDeduplicationOwnership _deduplicationOwnership;
        private ConfigPatchIdSet _activePatches;
        private HashSet<TKey> _patchAppendedKeys;
        private Dictionary<TKey, TInfo> _exclusivelyOwnedItems;
        private Dictionary<TKey, TInfo> _soloStorageItems;
        private Dictionary<TKey, TKey> _aliasToRealKey;
        private GameConfigLibrary(GameConfigRuntimeStorageMode storageMode, Dictionary<TKey, TInfo> soloStorageItems, GameConfigLibraryDeduplicationStorage<TKey, TInfo> deduplicationStorage, GameConfigDeduplicationOwnership deduplicationOwnership, HashSet<ExperimentVariantPair> activePatches, IGameConfigDataRegistry registry)
        {
        }

        private GameConfigLibrary(GameConfigRuntimeStorageMode storageMode, Dictionary<TKey, TInfo> soloStorageItems, GameConfigLibraryDeduplicationStorage<TKey, TInfo> deduplicationStorage, GameConfigDeduplicationOwnership deduplicationOwnership, HashSet<ExperimentVariantPair> activePatches)
        {
        }

        public int SpecializationSpecificDuplicationAmount { get; }

        private Dictionary<TKey, TInfo> _infos;
        public struct KeysEnumerable<TKey, TInfo>
        {
            private GameConfigLibrary<TKey, TInfo> _library;
        }

        public struct ValuesEnumerable<TKey, TInfo>
        {
            private GameConfigLibrary<TKey, TInfo> _library;
        }
    }
}